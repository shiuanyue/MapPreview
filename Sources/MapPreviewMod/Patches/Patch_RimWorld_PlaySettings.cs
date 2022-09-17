using HarmonyLib;
using LunarFramework.Patching;
using RimWorld;
using Verse;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming

namespace MapPreview.Patches;

[PatchGroup("Main")]
[HarmonyPatch(typeof(PlaySettings))]
internal class Patch_RimWorld_PlaySettings
{
    [HarmonyPostfix]
    [HarmonyPatch("DoPlaySettingsGlobalControls")]
    private static void DoPlaySettingsGlobalControls(WidgetRow row, bool worldView)
    {
        if (worldView)
        {
            bool prev = ModInstance.Settings.EnableMapPreview;
            row.ToggleableIcon(ref ModInstance.Settings.EnableMapPreview, TexButton.TogglePauseOnError, "MapPreview.World.ShowHidePreview".Translate(), SoundDefOf.Mouseover_ButtonToggle);
            if (prev != ModInstance.Settings.EnableMapPreview) Patch_RimWorld_WorldInterface.Refresh();
        }
    }
}
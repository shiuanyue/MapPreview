using UnityEngine;
using Verse;

namespace MapPreview;

public class ModInstance : Mod
{
    public static Settings Settings;

    public ModInstance(ModContentPack content) : base(content)
    {
        Settings = GetSettings<Settings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        Settings.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory() => "Map Preview";
}
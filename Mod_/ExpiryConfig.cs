using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace ExpiryMode.Mod_
{
    public class ExpiryConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        [Header("Joke Config")]
        [Label("Skeletron PogChamp")]
        [DefaultValue(false)]
        [Tooltip("Makes Skeletron Pog.\n\nCredit: ScuttleBaka A-Press#0248 on discord.")]
        public bool PogIsTrue;

        [Header("Overrides")]
        [Label("Change the Main Menu music")]
        [DefaultValue(true)]
        [ReloadRequired]
        [Tooltip("Toggle off to disable the music change. After changing this config, you must reload.\nIf any mods that change the menu music are enabled, this config will not affect anything.")]
        public bool MusicChange;

        [Header("QoL Config")]
        [Label("Radiance Darkness")]
        [DefaultValue(true)]
        [ReloadRequired]
        [Tooltip("Toggles whether or not the Radiance is blindingly dark.\nEnable if you are a die-hard and want a challenge.\n\nNOTE: This only affects the darkness of the TILES. Not the background.\nReload Required.")]
        public bool MakeBiomeDark;
    }
}
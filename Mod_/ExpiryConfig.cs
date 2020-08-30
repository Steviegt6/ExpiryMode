using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace ExpiryMode.Mod_
{
    public class ExpiryConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        [Header("Funny Configuration Settings")]
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

        /// <summary>
        /// Makes biomes not dark
        /// </summary>

        [Label("Space Suffocation Cough")]
        [DefaultValue(true)]
        [ReloadRequired]
        [Tooltip("Toggles the annoying cough the player does when suffocating (Yes, this makes no logical sense).")]
        public bool noCough;

        [Header("[c/FF0000:Difficulty Enhancers]")]
        [Label("Good Biome Buffs")]
        [DefaultValue(false)]
        [Tooltip("Toggles the good buffs you get from biomes")]
        public bool noGoodBuffs;
    }
}
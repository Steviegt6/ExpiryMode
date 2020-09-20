using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace ExpiryMode.Mod_
{
	[Label("Expiry Mode Client Changes")]
    public class ExpiryConfigClientSide : ModConfig
    {
        #region Meme Settings
        public override ConfigScope Mode => ConfigScope.ClientSide;
        [Header("Funny Configuration Settings")]
        [Label("Skeletron PogChamp")]
        [DefaultValue(false)]
        [Tooltip("Makes Skeletron Pog.\n\nCredit: ScuttleBaka A-Press#0248 on discord.")]
        public bool PogIsTrue;

        [Label("Change EoC Music")]
        [DefaultValue(false)]
        [Tooltip("I... Wh... I just..\nWhaat.")]
        public bool distractionDanceMusic;

        [Label("Change Hurt Sound")]
        [DefaultValue(false)]
        [Tooltip("Minecraft OOF > Terraria OOF")]
        public bool oofHurt;

        [Label("Pinky King Slime ([c/57f4ff:Experimental/Buggy])")]
        [DefaultValue(false)]
        [Tooltip("Turn King Slime into pinky")]
        public bool pinkySlimeKing;
        #endregion

        #region Overrides
        [Header("Overrides")]
        [Label("Change the Main Menu music")]
        [DefaultValue(true)]
        [ReloadRequired]
        [Tooltip("Toggle off to disable the music change. After changing this config, you must reload.\nIf any mods that change the menu music are enabled, this config will not affect anything.")]
        public bool MusicChange;
        #endregion

        /// <summary>
        /// Change Biome Brightness!
        /// </summary>

        #region QoL Config
        [Header("QoL Config")]
        [Label("Radiance Darkness")]
        [DefaultValue(true)]
        [ReloadRequired]
        [Tooltip("Toggles whether or not the Radiance is blindingly dark.\nEnable if you are a die-hard and want a challenge.\n\nNOTE: This only affects the darkness of the TILES. Not the background.\nReload Required.")]
        public bool MakeBiomeDark;

        [Label("Space Suffocation Cough")]
        [DefaultValue(true)]
        [ReloadRequired]
        [Tooltip("Toggles the annoying cough the player does when suffocating (Yes, this makes no logical sense).")]
        public bool noCough;
        #endregion
    }
	[Label("Expiry Mode Server Changes")]
    public class ExpiryConfigServerSide : ModConfig
    {
        #region Difficulty Enhancers
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [Header("[c/FF0000:Difficulty Enhancers]")]
        [Label("Good Biome Buffs")]
        [DefaultValue(true)]
        [Tooltip("Toggles the good buffs you get from biomes. Affects all players.")]
        public bool noGoodBuffs;

        [Label("Realistic Space")]
        [DefaultValue(false)]
        [Tooltip("Makes space a bit more realistic.")]
        public bool makeSpaceTerrible;

        [Header("Server Settings")]
        [Label("Post-Death Counter")]
        [DefaultValue(true)]
        [Tooltip("Toggles the death counter that displays after every death.")]
        public bool trackDeathCounter;
        #endregion
    }
}
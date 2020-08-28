using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace ExpiryMode.Mod_
{
    public class ExpiryConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        [Label("Toggles the PogTron texture on skeletron")]
        [DefaultValue(false)]
        public bool PogIsTrue;
    }
}
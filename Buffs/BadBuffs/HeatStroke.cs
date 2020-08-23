using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class HeatStroke : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Heat Stroke");
            Description.SetDefault("It's too hot!\nReduced melee speed");
            Main.debuff[this.Type] = true;
            Main.buffNoSave[this.Type] = true;
            Main.buffNoTimeDisplay[this.Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeSpeed = .4f;
        }
    }
}
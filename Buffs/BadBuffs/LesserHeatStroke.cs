using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class LesserHeatStroke : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lesser Heat Stroke");
            Description.SetDefault("You are feeling slightly better\nLesser reduced melee speed");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeSpeed = .7f;
        }
    }
}
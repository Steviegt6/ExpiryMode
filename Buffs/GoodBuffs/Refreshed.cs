using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.GoodBuffs
{
    public class Refreshed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Refreshed");
            Description.SetDefault("You feel nice");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 8;
            player.statLifeMax2 = (int)(player.statLifeMax2 * 1.1f);
        }
    }
}
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class GravityPlusPlus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gravity Tier II");
            Description.SetDefault("Gravity Pulls on you more then before");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
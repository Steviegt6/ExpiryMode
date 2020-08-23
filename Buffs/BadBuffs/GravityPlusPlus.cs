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
            Main.debuff[this.Type] = true;
            Main.buffNoSave[this.Type] = true;
            Main.buffNoTimeDisplay[this.Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class GravityPlus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gravity Tier I");
            Description.SetDefault("Gravity pulls you down more\nThe closer you get to the core of the earth, gravity pulls on you harder");
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
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class Murky : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Murky");
            Description.SetDefault("The murky environment doesn't make your skin pores feel good");
            Main.debuff[this.Type] = true;
            Main.buffNoSave[this.Type] = true;
            Main.buffNoTimeDisplay[this.Type] = false;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 1)
				player.lifeRegen = 1;
        }
    }
}
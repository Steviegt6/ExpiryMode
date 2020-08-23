using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class WaterPain : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Breath Vortex Tier I");
            Description.SetDefault("The water is not good for you");
            Main.debuff[this.Type] = true;
            Main.buffNoSave[this.Type] = true;
            Main.buffNoTimeDisplay[this.Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
			if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
			player.lifeRegenTime = 0;
			player.lifeRegen -= 50; 
        }
    }
}
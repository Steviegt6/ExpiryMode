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
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
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
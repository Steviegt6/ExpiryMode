using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class WaterPainPlus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Breath Vortex Tier II");
            Description.SetDefault("The water is sapping your life as we speak");
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
			player.lifeRegen -= 80; 
        }
    }
}
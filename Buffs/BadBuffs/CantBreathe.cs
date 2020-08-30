using ExpiryMode.Mod_;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class CantBreathe : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Space Suffocation");
            Description.SetDefault("Suffocating from the lack of air");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.GameUpdateCount % 20 == 0)
            {
                if (ModContent.GetInstance<ExpiryConfig>().noCough)
                {
                    if (Main.rand.NextFloat() <= 0.2f)
                    {
                        Main.PlaySound(SoundID.PlayerHit, player.Center);
                    }
                }
            }
            if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
			player.lifeRegenTime = 0;
			player.lifeRegen = -20;
        }
    }
}
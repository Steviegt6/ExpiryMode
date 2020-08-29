using ExpiryMode.Mod_;
using System;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class AbsoluteDoom : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Radiation Poisioning");
            Description.SetDefault("Your sense of reality is slipping from your mind");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {

            if (GetInstance<ExpiryConfig>().MakeBiomeDark)
            {
                Main.BlackFadeIn = 190;
                Lighting.Brightness(25, 25);
            }
            player.lifeRegenTime = 0;
            if (!Main.hardMode)
            {
                player.lifeRegen -= 1;
            }
            else
            {
                player.lifeRegen -= 7;
            }
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.2f);
            player.manaCost += 0.50f;
            player.manaRegen = 1;
            player.manaRegenDelay = 120;
            player.meleeDamageMult = .75f;
            if (GetInstance<ExpiryConfig>().MakeBiomeDark)
            {
                player.blackout = true;
            }
            player.breathMax = 0;
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
        }
        /*public class DoomedPlayer : ModPlayer
        {
            public override void PostUpdateBuffs()
            {
                if (player.HasBuff(BuffType<AbsoluteDoom>()))
                {
                    player.statDefense = (int)(player.statDefense * 0.1f);
                }
            }
        }*/
    }
}
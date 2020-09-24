using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class DoomLess : ModBuff
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
            player.lifeRegenTime = 0;
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.6f);
            player.manaCost += 0.35f;
            player.manaRegen = 1;
            player.meleeDamageMult = .85f;
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
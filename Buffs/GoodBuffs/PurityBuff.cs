using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Buffs.BadBuffs;

namespace ExpiryMode.Buffs.GoodBuffs
{
    public class PurityBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Purified");
            Description.SetDefault("The evil air no longer affects you");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HasBuff(ModContent.BuffType<PurityBuff>()))
            {
                player.buffImmune[BuffType<RottingAway>()] = true;
                player.buffImmune[BuffType<Fleshy>()] = true;
            }
        }
    }
}
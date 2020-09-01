using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class ManaDeficiency : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mana Deficiency");
            Description.SetDefault("Reduced Mana Regeneration\nCannot Consume Mana potions");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.manaRegenCount = 0;
            player.manaRegen -= 3;
        }
    }
}
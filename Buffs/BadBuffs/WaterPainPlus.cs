using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class WaterPainPlus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Breath Vortex Tier II");
            Description.SetDefault("The water is sapping your life as we speak");
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
            player.lifeRegen -= 80;
        }
    }
}
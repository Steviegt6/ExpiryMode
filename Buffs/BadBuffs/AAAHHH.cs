using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class AAAHHH : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("AAAHHH");
            Description.SetDefault("Your flesh is turning into ash");
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
            player.lifeRegen -= 5;
        }
    }
}
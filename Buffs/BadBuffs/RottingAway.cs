using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class RottingAway : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rotting Away");
            Description.SetDefault("The corruption air rots your skin");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 2;
            player.statDefense -= 5;
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.8f);
        }
    }
}
using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class HeatStroke : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Heat Stroke");
            Description.SetDefault("It's too hot!\nReduced melee speed");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeSpeed = .4f;
        }
    }
}
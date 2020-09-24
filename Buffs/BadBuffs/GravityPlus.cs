using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class GravityPlus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gravity Tier I");
            Description.SetDefault("Gravity pulls you down more\nThe closer you get to the core of the earth, gravity pulls on you harder");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
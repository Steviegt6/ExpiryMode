using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.MiscBuffs
{
    public class Paralysis : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Paralysis");
            Description.SetDefault("You cannot move!\nNote to all: Not fully implemented");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
            Main.pvpBuff[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity.Y = 0;
            npc.velocity.X = 0;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.velocity.X = 0;
            player.velocity.Y = 0;
        }
    }
}
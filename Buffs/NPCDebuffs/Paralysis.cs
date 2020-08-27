using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.NPCDebuffs
{
    public class Paralysis : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Paralysis");
            Description.SetDefault("You cannot move!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity.Y = 0;
            npc.velocity.X = 0;
        }
    }
}
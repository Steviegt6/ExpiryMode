using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Buffs.BadBuffs
{
    public class RadiatedWater : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Radiated");
            Description.SetDefault("Your radiation levels are dangerously high!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
                player.lifeRegen = 0;
            player.lifeRegen -= 40;
            player.statDefense = 0;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
                npc.lifeRegen = 0;
            npc.lifeRegen -= 90;
            npc.defense = 0;
        }
    }
}
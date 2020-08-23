using InfiniteSuffering;
using InfiniteSuffering.Waters;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using InfiniteSuffering.Buffs.BadBuffs;
using Microsoft.Xna.Framework;


namespace InfiniteSuffering.NPCs
{
	public class RadioactiveZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radioactive Zombie");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[16];
		}
        public override void SetDefaults()
        {
            npc.buffImmune[BuffType<RadiatedWater>()] = true;
            npc.width = 32;
            npc.height = 24;
            npc.damage = 27;
            npc.defense = 10;
            npc.lifeMax = 110;
            npc.HitSound = SoundID.NPCHit9;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = NPCID.Zombie;
            Main.npcFrameCount[npc.type] = 16;
            aiType = NPCID.Zombie;
            animationType = NPCID.Guide;
            if (Main.hardMode)
            {
                npc.damage = 52;
                npc.defense = 20;
                npc.knockBackResist = 0.3f;
            }
            else
            {
                npc.damage = 27;
                npc.defense = 10;
                npc.knockBackResist = .15f;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (!Main.hardMode)
            {
                target.AddBuff(BuffType<RadiatedWater>(), 60);
            }
            else
            {
                target.AddBuff(BuffType<RadiatedWater>(), 300);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.GetModPlayer<Mod_.InfiniteSuffPlayer>().ZoneRadiated && !Main.dayTime ? .8f : 0f;
		}
        public override void FindFrame(int frameHeight)
        {
            if (npc.frame.Y / npc.frame.Height > 15)
            {
                npc.frame.Y = 0 * npc.frame.Height;
            }
            /*npc.frameCounter = 1f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
            npc.spriteDirection = npc.direction;*/
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            Dust dust;
            Vector2 position = npc.Center;
            for (int i = 0; i < 20; i++)
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
            if (npc.life <= 0)
            {
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
                dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 30, 30, 275, npc.direction * -1, -1f * (npc.direction * -1), 0, new Color(8, 255, 0), 1f)];
            }

        }
        /*public override void NPCLoot()
		{
            if (Main.rand.Next(1) == 1)
                Item.NewItem(npc.getRect(), ItemID.Gel, 1);
            if (Main.rand.Next(2) == 1)
                Item.NewItem(npc.getRect(), ItemID.Gel, 2);
            if (Main.rand.Next(3) == 1)
                Item.NewItem(npc.getRect(), ItemID.Gel, 3);
            if (Main.rand.Next(4) == 1)
                Item.NewItem(npc.getRect(), ItemID.Gel, 4);
            if (Main.rand.Next(5) == 1)
                Item.NewItem(npc.getRect(), ItemID.Gel, 5);
			if (Main.rand.Next(6) == 1)
				Item.NewItem(npc.getRect(), ItemID.Gel, 6);
		}*/
	}
}
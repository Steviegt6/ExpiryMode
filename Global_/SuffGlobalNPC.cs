using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria.Enums;
using ExpiryMode.Buffs.MiscBuffs;
using ExpiryMode.Mod_;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.Config;

namespace ExpiryMode.Global_
{
	public class SuffGlobalNPC : GlobalNPC
    {
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (GetInstance<ExpiryConfig>().PogIsTrue)
            {
                if (npc.type == NPCID.SkeletronHead)
                {
                    spriteBatch.Draw(GetTexture("ExpiryMode/Assets/SkeletronPog"), npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.Size / 2f, npc.scale, npc.velocity.X > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                    return false;
                }
                if (npc.type == NPCID.SkeletronHand)
                {
                    spriteBatch.Draw(GetTexture("ExpiryMode/Assets/PogFist"), npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.Size / 2, npc.scale, SpriteEffects.None, 0);
                    return false;
                }
            }
            return true;
        }
        public override void SetDefaults(NPC npc)
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                #region NPC Life Scaling
                if (Main.hardMode && !Main.expertMode && !npc.friendly)
                {
                    npc.lifeMax = (int)(npc.lifeMax * 1.8f);
                }
                else if (!Main.hardMode && !Main.expertMode && !npc.friendly)
                {
                    npc.lifeMax = (int)(npc.lifeMax * 1.4f);
                }
                if (Main.hardMode && Main.expertMode && !npc.friendly)
                {
                    npc.lifeMax = (int)(npc.lifeMax * 2f);
                }
                else if (!Main.hardMode && Main.expertMode && !npc.friendly)
                {
                    npc.lifeMax = (int)(npc.lifeMax * 1.6f);
                }
            }
            #endregion
            #region NPC Defense Scaling (Not Much)
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (Main.hardMode && !Main.expertMode && !npc.friendly)
                {
                    npc.defense = (int)(npc.defense * 1.2f);
                }
                else if (!Main.hardMode && !Main.expertMode && !npc.friendly)
                {
                    npc.defense = (int)(npc.defense * 1.075f);
                }
                if (Main.hardMode && Main.expertMode && !npc.friendly)
                {
                    npc.defense = (int)(npc.defense * 1.35f);
                }
                else if (!Main.hardMode && Main.expertMode && !npc.friendly)
                {
                    npc.defense = (int)(npc.defense * 1.1f);
                }
                #endregion
            }
            #region BuffImmune
            if (npc.boss)
            {
                npc.buffImmune[BuffType<Paralysis>()] = true;
            }
            #endregion
        }
        public override void PostAI(NPC npc)
        {
            if (npc.boss)
            {
                npc.buffImmune[BuffType<Paralysis>()] = true;
            }
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (!npc.boss && !npc.CanBeChasedBy())
                {
                    npc.lifeRegen += 5;
                }
                if (!npc.boss)
                {
                    npc.lifeRegen += 2;
                }
            }
        }
        public override bool PreAI(NPC npc)
        {
            if (!npc.boss && npc.HasBuff(BuffType<Paralysis>()))
            {
                /*npc.velocity.X = 0;
                npc.velocity.Y = 0;
                npc.spriteDirection = 1;
                npc.direction = 1;*/
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (!Main.hardMode && !Main.expertMode && !npc.boss)
                {
                    damage = (int)(damage * 1.6f);
                }
                else if (Main.hardMode && !Main.expertMode && !npc.boss)
                {
                    damage = (int)(damage * 1.9f);
                }
                if (Main.expertMode && !Main.hardMode)
                {
                    damage = (int)(damage * 1.75f);
                }
                else if (Main.expertMode && Main.hardMode)
                {
                    damage = (int)(damage * 2.2f);
                }
            }
        }
        public override bool PreNPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Bunny)
            {
                if (Main.rand.Next(12) == 1)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BunnyEar>(), 1);
            }
            if (npc.type == NPCID.Bunny)
            {
                if (Main.rand.Next(12) == 1)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BunnyEar>(), 2);
            }
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    if (!NPC.downedSlimeKing && !NPC.downedBoss1)
                    {
                        Main.NewTextMultiline($"Your exceptionally difficult first hurdle has been overcome.", false, Color.Firebrick);
                    }
                    else if (!NPC.downedBoss1)
                    {
                        Main.NewTextMultiline($"I see you are advancing quick. This is suprising even me...", false, Color.Firebrick);
                    }
                }
                if (npc.boss && npc.type >= NPCID.EaterofWorldsHead && npc.type <= NPCID.EaterofWorldsTail)
                {
                    if (!NPC.downedBoss2)
                    {
                        Main.NewText($"A worm of corrupt beginnings and cruel ends, downed to you.", Color.LightCyan, true);
                    }
                }
                if (npc.type == NPCID.KingSlime)
                {
                    if (!NPC.downedBoss1 && !NPC.downedSlimeKing)
                    {
                        Main.NewText("Your first hurdle has been overcome.", Color.Blue, true);
                    }
                    else if (!NPC.downedSlimeKing)
                    {
                        Main.NewText("You killed a slime king? What is so suprising about that?", Color.Blue, true);
                    }
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    if (!NPC.downedBoss2)
                    {
                        Main.NewText($"I will haunt you 'till the day you die.", Color.Fuchsia, true);
                    }
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    if (GetInstance<ExpiryConfig>().PogIsTrue)
                    {
                        CombatText.NewText(npc.Hitbox, Color.White, "Thank you SkuttleBaka", false, false);
                    }
                    if (!NPC.downedBoss3)
                    {
                        Main.NewText($"A spooky scary skeleton sends shivers down your spine.", Color.SlateGray, true);
                    }
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    if (!Main.hardMode)
                    {
                        Main.NewTextMultiline($"Well, you somehow managed to get here. I assure you, you are not getting much further.", false, Color.DarkRed);
                    }
                    if (npc.boss /*&& npc.type <= NPCID.Spazmatism && npc.type >= NPCID.Retinazer*/)
                    {
                        // downedMechBoss1 == destroyer
                        // 2 = twins
                        // 3 skelly prime
                        if (!NPC.downedMechBoss2)
                        {
                            Main.NewText($"The notorious twins... Defeated? This is quite unbelievable. I've got my EYE on you...", Color.DarkRed, true);
                        }
                    }
                    if (npc.type == NPCID.SkeletronPrime)
                    {
                        // downedMechBoss1 == destroyer
                        // 2 = twins
                        // 3 skelly prime
                        if (!NPC.downedMechBoss3)
                        {
                            Main.NewText($"Damn, I even upgraded him and he was as useless as ever.", Color.DarkRed, true);
                        }
                    }
                }
            }
            return true;
        }
        public override void NPCLoot(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            if (player.GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
            {
                if (!npc.friendly && Main.rand.NextFloat() <= 0.075f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<RadioactiveSoulThingy>(), 1);
                }
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (player.ZoneDungeon)
                {
                    spawnRate = (spawnRate / 3);
                    maxSpawns = (maxSpawns / 3);
                }
                else
                {
                    spawnRate = spawnRate * 1;
                    maxSpawns = maxSpawns * 1;
                }
            }
        }
        public override bool Autoload(ref string name)
        {
            return mod.Properties.Autoload;
        }
    }
}
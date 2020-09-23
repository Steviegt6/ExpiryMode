using ExpiryMode.Buffs.MiscBuffs;
using ExpiryMode.Items.Equippables.Accessories;
using ExpiryMode.Items.Materials;
using ExpiryMode.Mod_;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using System.Net;

namespace ExpiryMode.Global_
{
    public class SuffGlobalNPC : GlobalNPC
    {
        public override bool CheckDead(NPC npc)
        {
            return true;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                #region !Boss regen
                if (!npc.boss && !npc.friendly && !Main.hardMode && !Main.expertMode)
                {
                    npc.lifeRegen += 8;
                }
                else if (!npc.boss && !npc.friendly && Main.hardMode && !Main.expertMode)
                {
                    npc.lifeRegen += 16;
                }
                else if (!npc.boss && !npc.friendly && !Main.hardMode && Main.expertMode)
                {
                    npc.lifeRegen += 12;
                }
                else if (!npc.boss && !npc.friendly && Main.hardMode && Main.expertMode)
                {
                    npc.lifeRegen += 24;
                }
                #endregion
                #region Boss Regen
                if (npc.boss && !Main.hardMode && !Main.expertMode)
                {
                    npc.lifeRegen += 6;
                }
                else if (npc.boss && Main.hardMode && !Main.expertMode)
                {
                    npc.lifeRegen += 12;
                }
                else if (npc.boss && !Main.hardMode && Main.expertMode)
                {
                    npc.lifeRegen += 9;
                }
                else if (npc.boss && Main.hardMode && Main.expertMode)
                {
                    npc.lifeRegen += 18;
                }
                #endregion
            }
        }
        public override void BuffTownNPC(ref float damageMult, ref int defense)
        {
            defense += 10;
            damageMult = 1.3f;
        }
        public override void GetChat(NPC npc, ref string chat)
        {
            Mod thorium = ModLoader.GetMod("ThoriumMod");
            int armsDealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            int merchant = NPC.FindFirstNPC(NPCID.Merchant);
            int travellingMerchant = NPC.FindFirstNPC(NPCID.TravellingMerchant);
            Player player = Main.player[Main.myPlayer];
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (npc.type == NPCID.ArmsDealer)
                {
                    if (Main.rand.NextFloat() <= 0.2f && !player.HasItem(ItemID.GoldCoin))
                    {
                        chat = "These guns ain't that cheap, so get some money!";
                    }
                }
                if (npc.type == NPCID.Guide)
                {
                    if (Main.rand.NextFloat() <= 0.25f && SuffWorld.ExpiryModeIsActive)
                    {
                        chat = "In Expiry Mode, enemies regenerate life, do more damage, have more life, and are overall more versatile. During the night time hours, it is wise to not go out, as the"
                            + " enemies can easily overrun you.";
                    }
                    if (Main.rand.NextFloat() <= 0.1f)
                    {
                        chat = $"You know, I heard that voodoo doll looks like me is high on {Main.npc[armsDealer].GivenName}'s 'want' list.";
                    }
                }
                if (npc.type == NPCID.PartyGirl)
                {
                    if (Main.rand.NextFloat() < .05f)
                    {
                        chat = "I don't really like the feeling of the air right now... Well, all the more reason to party!";
                    }
                }
                if (npc.type == NPCID.TravellingMerchant)
                {
                    if (Main.rand.NextFloat() < .1f)
                    {
                        chat = $"My wares are very worth it! {Main.npc[merchant].GivenName} has no taste whatsoever.";
                    }
                }
                if (npc.type == NPCID.Merchant)
                {
                    if (Main.rand.NextFloat() < .1f)
                    {
                        chat = $"{Main.npc[travellingMerchant].GivenName} makes no sense. Refrain from listening to him.";
                    }
                }
                if (ModLoader.GetMod("ThoriumMod") != null && npc.type == NPCID.Truffle)
                {
                    int cook = NPC.FindFirstNPC(ModLoader.GetMod("ThoriumMod").NPCType("Cook"));
                    if (Main.rand.NextFloat() < .15f)
                    {
                        if (Main.npc.Any(n => n.active && n.type == thorium.NPCType("Cook")))
                        {
                            chat = $"That {Main.npc[cook].GivenName} character keeps staring, and it's starting to unsettle me!";
                        }
                    }
                }
                if (thorium != null && npc.type == thorium.NPCType("Cook"))
                {
                    int cook = NPC.FindFirstNPC(ModLoader.GetMod("ThoriumMod").NPCType("Cook"));
                    if (Main.rand.NextFloat() < .15f)
                    {
                        if (thorium != null && npc.type ==/*Main.npc.Any(n => n.active && n.type == */thorium.NPCType("Cook"))
                        {
                            chat = $"{Main.npc[truffle].GivenName} is really starting to make me drool. Please let me cook him.";
                        }
                    }
                }
                if (npc.type == NPCID.TaxCollector)
                {
                    if (Main.rand.NextFloat() < .05f)
                    {
                        chat = "Bah! Get out of my sight. I am not in a good mood.";
                    }
                }
                if (npc.type == NPCID.Wizard)
                {
                    if (Main.rand.NextFloat() < .05f)
                    {
                        chat = "Want to hear a joke? No? Ok.";
                    }
                }
            }
        }
        // TODO: ...Remember. Make drops for the bump stock after all this...
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (GetInstance<ExpiryConfigClientSide>().PogIsTrue)
            {
                if (npc.type == NPCID.SkeletronHead)
                {
                    spriteBatch.Draw(GetTexture("ExpiryMode/Assets/SkeletronPog"), npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.Size / 2f, npc.scale, npc.velocity.X > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                    return false;
                }
            }
            if (GetInstance<ExpiryConfigClientSide>().pinkySlimeKing)
            {
                //spriteBatch.Draw(GetTexture("ExpiryMode/Assets/PinkySlimeCrown"), Main.npc[NPC.FindFirstNPC(NPCID.KingSlime)].Center- Main.screenPosition + new Vector2(0, 30), npc.frame, drawColor, npc.rotation, npc.Size / 1.6f, npc.scale, SpriteEffects.None, 0);
                if (npc.type == NPCID.KingSlime)
                {
                    spriteBatch.Draw(GetTexture("ExpiryMode/Assets/PinkySlimeKing"), npc.Center - Main.screenPosition, npc.frame, drawColor, npc.rotation, npc.Size / 1.6f, npc.scale, SpriteEffects.None, 0);
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
            }
            #endregion
            #region BuffImmune
            if (npc.boss || npc.type == NPCID.GolemHead || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight || npc.type == NPCID.SolarCrawltipedeTail)
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
            /*if (npc.type == NPCID.GreenSlime ||
                npc.type == NPCID.BlueSlime ||
                npc.type == NPCID.PurpleSlime ||
                npc.type == NPCID.YellowSlime ||
                npc.type == NPCID.RedSlime ||
                npc.type == NPCID.BlackSlime ||
                npc.type == NPCID.Pinky ||
                npc.type == NPCID.MotherSlime ||
                npc.type == NPCID.BabySlime ||
                npc.type == NPCID.IceSlime ||
                npc.type == NPCID.SandSlime ||
                npc.type == NPCID.DungeonSlime ||
                npc.type == NPCID.UmbrellaSlime ||
                npc.type == NPCID.SlimeRibbonGreen ||
                npc.type == NPCID.SlimeRibbonRed ||
                npc.type == NPCID.SlimeRibbonYellow ||
                npc.type == NPCID.SlimeRibbonWhite ||
                npc.type == NPCID.SlimeMasked)
            {
                npc.ai[1] = -1f;
            }*/
        }
        public override bool PreAI(NPC npc)
        {
            if (!npc.boss && npc.HasBuff(BuffType<Paralysis>()))
            {
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
        /*public override bool PreNPCLoot(NPC npc)
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
                    if (GetInstance<ExpiryConfigClientSide>().PogIsTrue)
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
                    if (npc.boss /*&& npc.type <= NPCID.Spazmatism && npc.type >= NPCID.Retinazer)
                    {
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
        }*/
        public override void NPCLoot(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            if (player.GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated && Main.hardMode && !npc.boss)
            {
                if (Main.rand.NextFloat() <= .075f)
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
/* Ideas for drops:
Duke Fishron: Sharknado Staff
Eye of Cthulhu: 
*/
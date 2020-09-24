using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.NPCs.TownNPCs
{
    [AutoloadHead]
    public class WarVeteran : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Juaquin";

                case 1:
                    return "Ryan";

                case 2:
                    return "William";

                default:
                    return "Jack";
            }
        }

        public override string GetChat()
        {
            Player player = Main.player[Main.myPlayer];
            int armsDealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (armsDealer >= 0 && Main.rand.NextBool(4))
            {
                return $"Can you believe {Main.npc[armsDealer].GivenName} is trying to 1-UP me with his sales?\nYeah, I know. I win.";
            }
            switch (Main.rand.Next(6))
            {
                case 0:
                    if (player.townNPCs > 2)
                    {
                        return "All these people are getting on my nerves. It's a good thing I have guns.";
                    }
                    break;

                case 1:
                    return "You see this strap around my body? This ain't for show, kid.";

                case 2:
                    return $"These scars didn't come from nothing.";

                case 3:
                    return $"What is your deal with me? All I do is sell guns!";

                case 4:
                    return $"Some call me crazy. Some call me stupid. Some call me violent. I call myself protective.";

                default:
                    return "Hurry! Buy one bullet get one bullet for the same price!";
            }
            return base.GetChat();
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Guns";
            button2 = "Ammo";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.Handgun);
            nextSlot++;
        }

        // TODO: Make second shop work, as it is VERY fucking faulty rn

        public override void NPCLoot()
        {
            //Item.NewItem(npc.getRect(), ItemType<Items.Armor.ExampleCostume>());
        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }

        public override void OnGoToStatue(bool toKingStatue)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = mod.GetPacket();
                packet.Write((byte)npc.whoAmI);
                packet.Send();
            }
            else
            {
                StatueTeleport();
            }
        }

        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }
                Dust.NewDustPerfect(npc.Center + position, DustID.Smoke, Vector2.Zero).noGravity = true;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }
    }
}
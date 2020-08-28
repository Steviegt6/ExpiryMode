using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Graphics.Shaders;
using ExpiryMode.Buffs.BadBuffs;

namespace ExpiryMode.Projectiles
{
    public class BiohazardBird : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Biohazard Bird");
            Main.projFrames[projectile.type] = 8; // Define frames
            Main.frameRate = 6;
        }
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 500;
            projectile.light = 0f;
            projectile.ignoreWater = false;
            projectile.damage = 32;
            projectile.penetrate = 1;
            drawOffsetX = -15;
            drawOriginOffsetX = -15;
            drawOriginOffsetY = -20;
            projectile.ranged = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Pop"), projectile.position);
                //case SoundLoader.customSoundType:
                //SoundLoader.customSoundInstances[num].Stop();
                //SoundLoader.customSoundInstances[num] = SoundLoader.CustomSounds[num].CreateInstance();
                if (Main.rand.NextFloat() < 1f)
                {
                    if (Main.rand.NextFloat() < 1f)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = projectile.position;
                        for (int i = 0; i < 12; i++)
                            dust = Main.dust[Terraria.Dust.NewDust(position, 12, 12, 73, 0f, 0f, 0, new Color(255, 125, 0), 1f)];
                        for (int i = 0; i < 18; i++)
                        {
                            dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 73, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
                            dust.shader = GameShaders.Armor.GetSecondaryShader(56, Main.LocalPlayer);
                            dust.fadeIn = 1.144737f;
                        }
                    }

                }

            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
                target.AddBuff(BuffType<RadiatedWater>(), 300);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Pop"), projectile.position);
                if (Main.rand.NextFloat() < 1f)
                {
                    if (Main.rand.NextFloat() < 1f)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = projectile.position;
                        for (int i = 0; i < 12; i++)
                            dust = Main.dust[Terraria.Dust.NewDust(position, 12, 12, 73, 0f, 0f, 0, new Color(255, 125, 0), 1f)];
                        for (int i = 0; i < 18; i++)
                        {
                            dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 73, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
                            dust.shader = GameShaders.Armor.GetSecondaryShader(56, Main.LocalPlayer);
                            dust.fadeIn = 1.144737f;
                        }
                    }

                }

            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Pop"), projectile.position);
            if (Main.rand.NextFloat() < 1f)
            {
                if (Main.rand.NextFloat() < 1f)
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = projectile.position;
                    for (int i = 0; i < 12; i++)
                        dust = Main.dust[Terraria.Dust.NewDust(position, 12, 12, 73, 0f, 0f, 0, new Color(255, 125, 0), 1f)];
                    for (int i = 0; i < 18; i++)
                    {
                        dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 73, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
                        dust.shader = GameShaders.Armor.GetSecondaryShader(56, Main.LocalPlayer);
                        dust.fadeIn = 1.144737f;
                    }
                }
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffType<RadiatedWater>(), 120, false);
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Pop"), projectile.position);
                if (Main.rand.NextFloat() < 1f)
                {
                    if (Main.rand.NextFloat() < 1f)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = projectile.position;
                        for (int i = 0; i < 12; i++)
                            dust = Main.dust[Terraria.Dust.NewDust(position, 12, 12, 73, 0f, 0f, 0, new Color(255, 125, 0), 1f)];
                        for (int i = 0; i < 18; i++)
                        {
                            dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 73, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
                            dust.shader = GameShaders.Armor.GetSecondaryShader(56, Main.LocalPlayer);
                            dust.fadeIn = 1.144737f;
                        }
                    }

                }

            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffType<RadiatedWater>(), 120, false);
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                //if (Main.netMode == NetmodeID.MultiplayerClient)
                /*{
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("this is multiplayer bitch"), Color.White);
                    target.AddBuff(BuffType<RadiatedWater>(), 120, false);
                }*/
                projectile.Kill();
                /* SoundID.62 == Grenade Explosion */
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Pop"), projectile.position);
                if (Main.rand.NextFloat() < 1f)
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = projectile.position;
                    for (int i = 0; i < 12; i++)
                        dust = Main.dust[Terraria.Dust.NewDust(position, 12, 12, 73, 0f, 0f, 0, new Color(255, 125, 0), 1f)];
                    for (int i = 0; i < 18; i++)
                    {
                        dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 73, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
                        dust.shader = GameShaders.Armor.GetSecondaryShader(56, Main.LocalPlayer);
                    }

                }

            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Rectangle frame = new Rectangle(0, projectile.frame * 72, 56, 72);
            spriteBatch.Draw(GetTexture("ExpiryMode/Projectiles/BiohazardBird"), projectile.position + new Vector2(projectile.width, projectile.height) / 2 - Main.screenPosition, frame, lightColor, projectile.rotation + (float)0.1 * projectile.spriteDirection, new Vector2(56, 72) / 2, projectile.scale, projectile.spriteDirection > 0 ? SpriteEffects.None : SpriteEffects.FlipVertically, 0);
            return false; // Return false to stop drawing more 
        }
        public override void AI()
        {
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }
            Player player = Main.LocalPlayer;
            projectile.spriteDirection = projectile.velocity.X > 0 ? 1 : -1;
            projectile.rotation = projectile.velocity.ToRotation();
            // AI BEHAVIOUR

            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC target = Main.npc[i];
                if (!target.friendly && target.CanBeChasedBy()/*target.type != NPCID.Bunny && target.type != NPCID.Bird && target.type != NPCID.Buggy && target.type != NPCID.Worm && target.type != NPCID.Grubby && target.type != NPCID.Squirrel && target.type != NPCID.TargetDummy*/)
                {
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    if (distance < 360f && target.active)
                    {
                        if (!target.friendly && Collision.CanHitLine(projectile.position, 32, 32, target.position, target.width, target.height))
                        {
                            distance = 2f / distance;

                            shootToX *= distance * 5;
                            shootToY *= distance * 5;

                            projectile.velocity.X = shootToX;
                            projectile.velocity.Y = shootToY;
                        }
                    }
                }
            }
        }
    }
}
/*
	Dust dust;
	// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
	Vector2 position = Main.LocalPlayer.Center;
	dust = Main.dust[Terraria.Dust.NewDust(position, 12, 12, 73, 0f, 0f, 0, new Color(255,125,0), 1f)];
	Dust dust;
	// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
	Vector2 position = Main.LocalPlayer.Center;
	dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 73, 0f, 0f, 0, new Color(255,0,0), 1f)];
	dust.shader = GameShaders.Armor.GetSecondaryShader(56, Main.LocalPlayer);
	dust.fadeIn = 1.144737f;

*/

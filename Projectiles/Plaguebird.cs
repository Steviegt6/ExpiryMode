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
	public class Plaguebird : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Plaguebird");
            Main.projFrames[projectile.type] = 8;
            Main.frameRate = 6;
		}
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 500;
            projectile.light = 0f;
            projectile.ignoreWater = false;
            projectile.damage = 21;
            projectile.penetrate = 1;
            drawOffsetX = -15;
            drawOriginOffsetX = -15;
            drawOriginOffsetY = -20;
        }
        /*public override bool OnTileCollide(Vector2 oldVelocity)
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
        }*/
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
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
                target.AddBuff(BuffType<RadiatedWater>(), 120);
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
                projectile.Kill();
                /* SoundID.62 == Grenade Explosion */
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
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Rectangle frame = new Rectangle(0, projectile.frame * 72, 56, 72);
            spriteBatch.Draw(GetTexture("ExpiryMode/Projectiles/BiohazardBird"), projectile.position + new Vector2(projectile.width, projectile.height) / 2 - Main.screenPosition, frame, lightColor, projectile.rotation + (float)0.1 * (projectile.spriteDirection), new Vector2(56, 72) / 2, projectile.scale, projectile.spriteDirection > 0 ? SpriteEffects.None : SpriteEffects.FlipVertically, 0);
            return false;
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
            Player player = Main.player[projectile.owner];
            projectile.rotation = player.Center.ToRotation();
            if (player.dead && !player.active)
            {
                projectile.Kill();
            }
            projectile.spriteDirection = projectile.velocity.X > 0 ? 1 : -1;
            projectile.rotation = projectile.velocity.ToRotation();
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            Player p = Main.player[projectile.owner];

            //Factors for calculations
            double deg = projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 128; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */
            projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 2f;
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

using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfiniteSuffering.Projectiles
{
    class SorrowSlash : ModProjectile
    {
        /*public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 45;
            projectile.height = 45;
            projectile.aiStyle = ProjectileID.Arkhalis;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true; //so you can't hit enemies through walls
            projectile.melee = true;
            projectile.localNPCHitCooldown = 0;
            projectile.usesLocalNPCImmunity = true;
        }



        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //3a: target.immune[projectile.owner] = 20;
            //3b: target.immune[projectile.owner] = 5;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            //return Color.White;
            return new Color(255, 255, 255, 0) * (1f - projectile.alpha / 255f);
        }

        public override void AI()
        {
            // Slow down
            projectile.velocity *= 0.98f;
            // Loop through the 4 animation frames, spending 5 ticks on each.
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }
            projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? 1 : -1));
            projectile.rotation = projectile.velocity.ToRotation();
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            // Since our sprite has an orientation, we need to adjust rotation to compensate for the draw flipping.
            if (projectile.spriteDirection == -1)
                projectile.rotation += MathHelper.Pi;
        }

        // Some advanced drawing because the texture image isn't centered or symetrical.
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int startY = frameHeight * projectile.frame;
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;
            origin.X = ((projectile.spriteDirection == 1) ? (sourceRectangle.Width - 40) : 40);

            Color drawColor = projectile.GetAlpha(lightColor);
            Main.spriteBatch.Draw(texture,
            projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
            sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);

            return false;
        }
        public override void AI()
        {
            Player player = Main.player[base.projectile.owner];
            float num = 0f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            if (base.projectile.spriteDirection == -1)
            {
                num = 3.14159274f;
            }
            Projectile projectile = base.projectile;
            int num3 = projectile.frame + 1;
            projectile.frame = num3;
            if (num3 >= Main.projFrames[base.projectile.type])
            {
                base.projectile.frame = 0;
            }
            base.projectile.soundDelay--;
            if (base.projectile.soundDelay <= 0)
            {
                Main.PlaySound(SoundID.Item1, base.projectile.Center);
                base.projectile.soundDelay = 24;
            }
            if (Main.myPlayer == base.projectile.owner)
            {
                if (player.channel && !player.noItems && !player.CCed)
                {
                    float scaleFactor6 = 1f;
                    if (player.inventory[player.selectedItem].shoot == base.projectile.type)
                    {
                        scaleFactor6 = player.inventory[player.selectedItem].shootSpeed * base.projectile.scale;
                    }
                    Vector2 vector2 = Main.MouseWorld - vector;
                    vector2.Normalize();
                    if (Utils.HasNaNs(vector2))
                    {
                        vector2 = Vector2.UnitX * (float)player.direction;
                    }
                    vector2 *= scaleFactor6;
                    if (vector2.X != base.projectile.velocity.X || vector2.Y != base.projectile.velocity.Y)
                    {
                        base.projectile.netUpdate = true;
                    }
                    base.projectile.velocity = vector2;
                }
                else
                {
                    base.projectile.Kill();
                }
            }
            Vector2 vector3 = base.projectile.Center + base.projectile.velocity * 3f;
            base.projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - base.projectile.Size / 2f;
            base.projectile.rotation = Utils.ToRotation(base.projectile.velocity) + num;
            base.projectile.spriteDirection = base.projectile.direction;
            base.projectile.timeLeft = 2;
            player.ChangeDir(base.projectile.direction);
            player.heldProj = base.projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float)System.Math.Atan2((double)(base.projectile.velocity.Y * (float)base.projectile.direction), (double)(base.projectile.velocity.X * (float)base.projectile.direction));
        }*/
    }
}

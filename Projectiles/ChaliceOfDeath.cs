using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Projectiles
{
    public class ChaliceOfDeath : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chalice of Death");
            Main.projFrames[projectile.type] = 7; // Define frames
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.timeLeft = 60;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Rectangle frame = new Rectangle(0, projectile.frame * 62, 32, 62);
            spriteBatch.Draw(GetTexture("ExpiryMode/Projectiles/ChaliceOfDeath"),
                projectile.position + new Vector2(projectile.width, projectile.height) / 2 - Main.screenPosition,
                frame, lightColor,
                projectile.rotation + (float)0.1 * projectile.spriteDirection,
                new Vector2(18, 36) / 2,
                projectile.scale,
                projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
            return false; // Return false to stop drawing more
        }

        public override void AI()
        {
            if (++projectile.frameCounter >= 3)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }
            Player player = Main.player[projectile.owner];
            Vector2 center = player.RotatedRelativePoint(player.itemLocation, true);

            projectile.Center = center;
            projectile.rotation = projectile.velocity.ToRotation() + (MathHelper.Pi / 180);
            projectile.spriteDirection = projectile.direction;
            // player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (projectile.velocity * projectile.direction).ToRotation();
        }
    }
}
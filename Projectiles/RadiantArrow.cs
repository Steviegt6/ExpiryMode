using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.Dust;
using ExpiryMode.Buffs.NPCDebuffs;
using Terraria.Graphics.Shaders;
using ExpiryMode.Buffs.BadBuffs;

namespace ExpiryMode.Projectiles
{
    public class RadiantArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiant Arrow");
            Main.projFrames[projectile.type] = 9; // Define frames
            Main.frameRate = 6;
        }
        public override void SetDefaults()
        {
            Player player = Main.player[Main.myPlayer];
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 400;
            projectile.light = 0f;
            projectile.ignoreWater = false;
            projectile.damage = player.HeldItem.damage;
            projectile.penetrate = 3;
            projectile.knockBack = 2;
            projectile.arrow = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
                Main.PlaySound(SoundID.Item93, projectile.position);
                projectile.Kill();
                Dust dust;
                Vector2 position = projectile.Center;
                for (int i = 20; i >= 0; i--) // I do this because i am a rebel
                {
                    dust = Main.dust[NewDust(position, 30, 30, 91, projectile.velocity.X, projectile.velocity.Y, 0, new Color(0, 255, 17), 1f)];
                    dust.noGravity = true;
                    dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
                }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Dust dust;
            Vector2 position = projectile.Center;
            for (int i = 20; i >= 0; i--) // I do this because i am a rebel
            {
                dust = Main.dust[NewDust(position, 30, 30, 91, projectile.velocity.X, projectile.velocity.Y, 0, new Color(0, 255, 17), 1f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
            }
            _ = Main.player[Main.myPlayer];
            target.AddBuff(BuffType<Paralysis>(), 30);
            target.AddBuff(BuffType<RadiatedWater>(), 30);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffType<RadiatedWater>(), 30);
            Dust dust;
            Vector2 position = projectile.Center;
            for (int i = 20; i >= 0; i--) // I do this because i am a rebel
            {
                dust = Main.dust[NewDust(position, 30, 30, 91, projectile.velocity.X, projectile.velocity.Y, 0, new Color(0, 255, 17), 1f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffType<RadiatedWater>(), 30);
            Dust dust;
            Vector2 position = projectile.Center;
            for (int i = 20; i >= 0; i--) // I do this because i am a rebel
            {
                dust = Main.dust[NewDust(position, 30, 30, 91, projectile.velocity.X, projectile.velocity.Y, 0, new Color(0, 255, 17), 1f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Rectangle frame = new Rectangle(0, projectile.frame * 36, 18, 32);
            spriteBatch.Draw(GetTexture("ExpiryMode/Projectiles/RadiantArrow"),
                projectile.position + new Vector2(projectile.width, projectile.height) / 2 - Main.screenPosition,
                frame, lightColor,
                projectile.rotation + (float)0.1 * projectile.spriteDirection,
                new Vector2(18, 32) / 2,
                projectile.scale,
                projectile.spriteDirection > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
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
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            projectile.velocity.Y = projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
            if (projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
            {
                projectile.velocity.Y = 16f;
            }
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = NewDustPerfect(position, 91, new Vector2(0f, 0f), 0, new Color(0, 255, 17), 1f);
            dust.noGravity = true;
            dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);

        }
    }
}
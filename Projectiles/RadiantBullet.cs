using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.Dust;
using ExpiryMode.Buffs.MiscBuffs;
using Terraria.Graphics.Shaders;
using ExpiryMode.Buffs.BadBuffs;
using System;

namespace ExpiryMode.Projectiles
{
    public class RadiantBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiant Bullet");
        }
        public override void SetDefaults()
        {
            Player player = Main.player[Main.myPlayer];
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            projectile.ranged = true;
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
            Dust dust;
            Vector2 position = projectile.position;
            for (int i = 20; i >= 0; i--) // I do this because i am a rebel
            {
                dust = Main.dust[NewDust(position, 30, 30, 91, 0, 0, 0, new Color(0, 255, 17), 1f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
            }
            projectile.Kill();  
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Dust dust;
            Vector2 position = projectile.position;
            for (int i = 20; i >= 0; i--) // I do this because i am a rebel
            {
                dust = Main.dust[NewDust(position, 30, 30, 91, 0, 0, 0, new Color(0, 255, 17), 1f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
            }
            _ = Main.player[Main.myPlayer];
            target.AddBuff(BuffType<Paralysis>(), 30);
            target.AddBuff(BuffType<RadiatedWater>(), 30);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffType<RadiatedWater>(), 30, false);
            target.AddBuff(BuffType<Paralysis>(), 30, false);
            Dust dust;
            Vector2 position = projectile.position;
            for (int i = 20; i >= 0; i--) // I do this because i am a rebel
            {
                dust = Main.dust[NewDust(position, 30, 30, 91, 0, 0, 0, new Color(0, 255, 17), 1f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffType<RadiatedWater>(), 30, false);
            target.AddBuff(BuffType<Paralysis>(), 30, false);
            Dust dust;
            Vector2 position = projectile.position;
            for (int i = 20; i >= 0; i--) // I do this because i am a rebel
            {
                dust = Main.dust[NewDust(position, 30, 30, 91, 0, 0, 0, new Color(0, 255, 17), 1f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
            }
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = NewDustPerfect(position, 91, new Vector2(0f, 0f), 0, new Color(0, 255, 17), 1f);
            dust.noGravity = true;
            dust.shader = GameShaders.Armor.GetSecondaryShader(61, Main.LocalPlayer);
        }
    }
}
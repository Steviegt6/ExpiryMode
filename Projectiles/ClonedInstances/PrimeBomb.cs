using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ExpiryMode.Util;

namespace ExpiryMode.Projectiles.ClonedInstances
{
    class PrimeBomb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Bomb");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BombSkeletronPrime);
            projectile.hostile = false;
            projectile.friendly = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(projectile.Center, new Vector2(oldVelocity.X, oldVelocity.Y), ProjectileID.ExplosiveBullet, 50, 50);
            projectile.Kill();
            return base.OnTileCollide(oldVelocity);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(projectile.Center, new Vector2(projectile.velocity.X, projectile.velocity.Y), ProjectileID.ExplosiveBullet, 50, 50);
            projectile.Kill();
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            Projectile.NewProjectile(projectile.Center, new Vector2(projectile.velocity.X, projectile.velocity.Y), ProjectileID.ExplosiveBullet, 50, 50);
            projectile.Kill();
            base.OnHitPvp(target, damage, crit);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            Projectile.NewProjectile(projectile.Center, new Vector2(projectile.velocity.X, projectile.velocity.Y), ProjectileID.ExplosiveBullet, 50, 50);
            projectile.Kill();
            base.OnHitPlayer(target, damage, crit);
        }
    }
}
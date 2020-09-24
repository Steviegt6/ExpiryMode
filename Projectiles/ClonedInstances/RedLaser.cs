using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Projectiles.ClonedInstances
{
    internal class RedLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Laser");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.PinkLaser);
            projectile.friendly = true;
            projectile.hostile = false;
        }
    }
}
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExpiryMode.Projectiles.ClonedInstances
{
    class RedLaser : ModProjectile
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
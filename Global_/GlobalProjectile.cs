using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ExpiryMode.Mod_;

namespace ExpiryMode.Global_
{
    public class GlobalProjectiles : GlobalProjectile
    {
        /*public override void SetDefaults(Projectile projectile)
        {
            if (projectile.owner == Main.myPlayer)
            {
                if (projectile.type == ProjectileID.Sharknado)
                {
                    projectile.friendly = true;
                    projectile.hostile = false;
                }
                if (projectile.type == ProjectileID.MiniSharkron && projectile.type == ProjectileID.Sharknado)
            }
        }*/
        // ask 4mbr0s3 2 for help here :ech:
        public override void ModifyHitPlayer(Projectile projectile, Player target, ref int damage, ref bool crit)
        {
            if (projectile.type == ProjectileID.PhantasmalDeathray)
            {
                damage = 999999;
            }
        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (Main.player[Main.myPlayer].GetModPlayer<InfiniteSuffPlayer>().bumpStock)
            {
                for (int numTimes = 0; numTimes <= 10; numTimes++)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0, 0, 25, Color.DarkOrange);
                }
                return true;
            }
            else
            {
                return base.OnTileCollide(projectile, oldVelocity);
            }
        }
    }
}
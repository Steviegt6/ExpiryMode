using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ExpiryMode.Mod_;
using log4net.Util;
using System.Security.Policy;

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
        public override void SetDefaults(Projectile projectile)
        {
        }
        public override bool CanHitPlayer(Projectile projectile, Player target)
        {
            if (projectile.owner == Main.myPlayer)
            {
                 return false;
            }
            return base.CanHitPlayer(projectile, target);
        }
        public override void PostAI(Projectile projectile)
        {
            if (projectile.owner == Main.myPlayer)
            {
                projectile.hostile = false;
                projectile.friendly = true;
            }
            base.PostAI(projectile);
        }
        public override void ModifyHitPlayer(Projectile projectile, Player target, ref int damage, ref bool crit)
        {
            if (projectile.type == ProjectileID.PhantasmalDeathray)
            {
                damage = 999999;
            }
        }
        public override void Kill(Projectile projectile, int timeLeft)
        {
            int numBees = Main.rand.Next(1, 4);
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (projectile.type == ProjectileID.Beenade)
                {
                    if (Main.rand.NextFloat() <= 0.15f)
                    {
                        for (int i = 0; i <= numBees; i++)
                        {
                            NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, NPCID.Bee);
                        }
                    }
                }
            }
        }
        public override bool? CanHitNPC(Projectile projectile, NPC target)
        {
            return base.CanHitNPC(projectile, target);
        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (Main.player[Main.myPlayer].GetModPlayer<InfiniteSuffPlayer>().bumpStock && projectile.type == ProjectileID.Bullet)
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
    public class MakeFriendly : GlobalProjectile
    {
        public override bool CloneNewInstances => true;
        public override bool InstancePerEntity => true;
        public bool defFriendly;
        public bool defNoHostile;
    }
}
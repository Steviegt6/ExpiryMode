/*using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExpiryMode.Projectiles
{
    class SorrowSlash : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            /*projectile.width = 45;
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
			base.projectile.width = 160;
			base.projectile.height = 160;
			base.projectile.ranged = true;
			base.projectile.timeLeft = 100;
			base.projectile.penetrate = -1;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.light = 0.35f;
			base.projectile.tileCollide = false;
			base.projectile.ownerHitCheck = true;
        }
		public override void AI()
		{
			Projectile projectile = Main.projectile[0];
			projectile.timeLeft = 2;
			if (projectile.frame == 0 || projectile.frame == 4 || projectile.frame == 5 || projectile.frame == 9)
			{
				projectile.friendly = false;
			}
			else
			{
				base.projectile.friendly = true;
			}
			int num = projectile.frameCounter + 1;
			projectile.frameCounter = num;
			if (num >= 4)
			{
				projectile.frameCounter = 0;
				Projectile projectile2 = projectile;
				num = projectile2.frame + 1;
				projectile2.frame = num;
				if (num >= Main.projFrames[projectile.type])
				{
					base.projectile.frame = 0;
				}
			}
			Player player = Main.player[projectile.owner];
			if (!player.channel)
			{
				base.projectile.Kill();
			}
			Vector2 ownerMountedCenter = player.RotatedRelativePoint(player.MountedCenter, true);
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2) + MathHelper.Clamp((float)(Main.mouseX - Main.screenWidth / 2), -500f, 500f) / 10f;
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2) + MathHelper.Clamp((float)(Main.mouseY - Main.screenHeight / 2), -500f, 500f) / 7f;
			projectile.rotation = Utils.ToRotation(projectile.DirectionTo(Main.MouseWorld));
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002458 File Offset: 0x00000658
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 20;
		}
	}
}*/
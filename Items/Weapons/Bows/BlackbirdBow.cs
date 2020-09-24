using ExpiryMode.Global_;
using ExpiryMode.Items.Materials;
using ExpiryMode.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Weapons.Bows
{
    public class BlackbirdBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Biohazard Bird Bow");
            Tooltip.SetDefault("Shoots Biohazard birds"
            + "\nThe birds inflict 'Radiated' to any NPC it hits\nHomes in on your enemies.");
        }

        public override void SetDefaults()
        {
            item.damage = 51;
            item.ranged = true;
            item.width = 32;
            item.height = 46;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ExpiryRarity.AcidicRarity;
            item.UseSound = SoundID.Item99;
            item.autoReuse = true;
            item.shoot = ProjectileType<BiohazardBird>();
            item.shootSpeed = 12f;
            item.crit = 12;
            item.reuseDelay = 8;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//Main.PlaySound(mod.GetLegacySoundSlot)
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 0f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
				position += muzzleOffset;
            }
			int numberProjectiles = 2 + Main.rand.Next(0); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(23)); // 23 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
            return true;
		}*/

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<RadianiteBarItem>(), 8);
            recipe.AddIngredient(ItemType<RadioactiveSoulThingy>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
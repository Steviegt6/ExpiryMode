using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ExpiryMode.Items.Materials;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Projectiles;
using Terraria;

namespace ExpiryMode.Items.Weapons.Magic
{
	public class WandoftheRaven : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wand of the Raven");
			Tooltip.SetDefault("Emits a spread of birds from your cursor.");
		}
		public override void SetDefaults()
		{
			item.damage = 24;
			item.magic = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.value = 10000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item73;
			item.autoReuse = true;
			item.shoot = ProjectileType<BiohazardBird>();
			item.shootSpeed = 12f;
			item.crit = 12;
            item.mana = 1;
            item.reuseDelay = 12;
			Item.staff[item.type] = true;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position = Main.MouseWorld;
			float numberProjectiles = 5f;
			float rotation = MathHelper.ToRadians(180f);
			int i = 0;
			while (i < numberProjectiles)
			{
				Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(speedX, speedY), MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
				i++;
			}
			return false;
		}
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
			
			
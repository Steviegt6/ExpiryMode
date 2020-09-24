/*using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Weapons.Swords
{
	public class BladeofSorrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blade of Sorrows");
			Tooltip.SetDefault("Not fully implemented yet, has no use as of now");
		}
		public override void SetDefaults()
		{
			item.damage = 32;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileType<Projectiles.SorrowSlash>();
			item.shootSpeed = 24f;
			item.noUseGraphic = true;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RadianiteBarItem", 12);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}*/
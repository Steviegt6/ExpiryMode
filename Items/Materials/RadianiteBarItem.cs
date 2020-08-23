using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace InfiniteSuffering.Items.Materials
{
	public class RadianiteBarItem : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Radianite Bar");
			Tooltip.SetDefault("Gleams with radioactive energy");
		}
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            //item.useTurn = true;
            //item.autoReuse = true;
            //item.useAnimation = 16;
            //item.useTime = 8;
            //item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            //item.createTile = mod.TileType("RadianiteBar");
            item.rare = ItemRarityID.LightRed;
            item.value = 12500;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RadianiteOreItem", 5);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
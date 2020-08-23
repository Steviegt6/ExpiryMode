using IL.Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Materials
{
	public class Paper : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Paper");
			Tooltip.SetDefault($"Looks like a doctor wrote it");
		}

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = ItemRarityID.White;
            item.maxStack = 999;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.SetResult(null, "Paper", 3);
            recipe.AddRecipe();
        }
    }
}
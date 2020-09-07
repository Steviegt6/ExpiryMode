using ExpiryMode.Global_;
using ExpiryMode.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Equippables.Armor.Biohazard
{
	[AutoloadEquip(EquipType.Body)]
	public class BiohazardBody : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Reinforced Hazmat Chestpiece");
			Tooltip.SetDefault("'A bit airtight but it's alright'");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = 12317;
			item.rare = ExpiryRarity.AcidicRarity;
			item.defense = 13;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 12);
			recipe.AddIngredient(ItemType<RadianiteBarItem>(), 16);
			recipe.AddIngredient(ItemType<RadioactiveSoulThingy>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
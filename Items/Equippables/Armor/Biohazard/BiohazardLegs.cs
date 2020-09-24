using ExpiryMode.Global_;
using ExpiryMode.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Equippables.Armor.Biohazard
{
    [AutoloadEquip(EquipType.Legs)]
    public class BiohazardLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reinforced Hazmat Leggings");
            Tooltip.SetDefault("'Without these ol' things, you would be dead meat'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12314;
            item.rare = ExpiryRarity.AcidicRarity;
            item.defense = 9;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 8);
            recipe.AddIngredient(ItemType<RadianiteBarItem>(), 14);
            recipe.AddIngredient(ItemType<RadioactiveSoulThingy>(), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
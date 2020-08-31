using ExpiryMode.Tiles.Decoration;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
 
namespace ExpiryMode.Items.Decoration
{
    public class BiohazardContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Labeled: 'Extremely Dangerous'\nDEVNOTE: Tile does not properly drop.");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 150;
            item.createTile = TileType<BiohazardBarrel>();
        }
 
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddIngredient(ItemID.YellowPaint, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
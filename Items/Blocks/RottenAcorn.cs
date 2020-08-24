using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Tiles.Trees;

namespace ExpiryMode.Items.Blocks
{
	public class RottenAcorn : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Nearly discentegrated");
		}
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 16;
			item.useTime = 8;
            item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 200;
			item.consumable = true;
            item.createTile = TileType<RottenSapling>();
			item.placeStyle = 0;
		}
	}
}
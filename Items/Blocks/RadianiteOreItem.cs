using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Tiles;

namespace ExpiryMode.Items.Blocks
{
	public class RadianiteOreItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radianite Ore");
			Tooltip.SetDefault("The emissivity of this object is fascinating");
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
			item.consumable = true;
            item.createTile = TileType<RadianiteOre>();
            item.value = 200;
			item.rare = ItemRarityID.LightRed;
		}
	}
}
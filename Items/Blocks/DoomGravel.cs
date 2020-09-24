using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Blocks
{
    public class DoomGravel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radioactive Stone");
            Tooltip.SetDefault("Even the dust it is made of is radioactive");
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
            item.createTile = TileType<ExpiryMode.Tiles.DoomGravel>();
            item.rare = ItemRarityID.Orange;
        }
    }
}
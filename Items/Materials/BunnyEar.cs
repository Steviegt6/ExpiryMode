using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Materials
{
    public class BunnyEar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bunny Ear");
            Tooltip.SetDefault("The blood is a little offsetting");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = ItemRarityID.White;
            item.maxStack = 999;
        }
    }
}
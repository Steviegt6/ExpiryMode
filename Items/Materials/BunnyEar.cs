using Terraria.ID;
using Terraria.ModLoader;

namespace InfiniteSuffering.Items.Materials
{
	public class BunnyEar : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bunny Ear");
			Tooltip.SetDefault("Pure as the forest itself");
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
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace InfiniteSuffering.Items.Materials
{
	public class RadioactiveSoulThingy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Calamitous Contagion");
            Tooltip.SetDefault("'Eminates an offsetting aura'");
            ItemID.Sets.ItemNoGravity[item.type] = true;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6)); // Note: TicksPerFrame, Frames
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 30;
			item.rare = ItemRarityID.Lime;
			item.maxStack = 999;
		}
	}
}
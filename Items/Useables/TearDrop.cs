using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Useables
{
    public class UseSoundID
    {
        public static LegacySoundStyle Swing = SoundID.Item1; // Just a test *wink*
    }
	public class TearDrop : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tear Drop");
			Tooltip.SetDefault("Calls upon the rain\nAction cannot be reversed\nDev Note: Might be a bit buggy");
		}
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.useAnimation = 20;
            item.useTime = 20;
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.HoldingUp;
            //item.UseSound = SoundID.Item44; 
            item.UseSound = SoundID.Item77;
        }
        public override bool CanUseItem(Player player)
        {
            return !Main.raining;
        }
        public override bool UseItem(Player player)
        {
            Main.raining = true;
            Main.rainTime = Main.rand.Next(3600, 36000);
            return true;
        }
    }
}
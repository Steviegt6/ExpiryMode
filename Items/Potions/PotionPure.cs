using ExpiryMode.Buffs.GoodBuffs;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Potions
{
	public class PotionPure : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purity Potion");
			Tooltip.SetDefault("Makes you immune to pure evil");
		}
        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTurn = true;
            item.useAnimation = 16;
            item.useTime = 16;
            item.maxStack = 30;
            item.consumable = true;
            item.width = 20;
            item.height = 28;
            item.value = 3213;
            item.rare = ItemRarityID.LightRed;
            item.buffType = BuffType<PurityBuff>();
            item.buffTime = 28800;
        }
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(null, "BunnyEar", 3);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

}
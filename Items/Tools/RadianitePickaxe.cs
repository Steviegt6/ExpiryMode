using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace InfiniteSuffering.Items.Tools
{
	public class RadianitePickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 8;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = 10;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
			item.pick = 115;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.Materials.RadianiteBarItem>(), 12);
			recipe.AddIngredient(ItemType<Items.Materials.RadioactiveSoulThingy>(), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
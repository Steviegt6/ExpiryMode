using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using System.Linq;

namespace ExpiryMode.Items.Materials
{
	public class PendantPiece : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Pendant Piece");
			Tooltip.SetDefault("Material\nIt could be used for something good...");
		}

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = ItemRarityID.Yellow;
            item.maxStack = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<PendantPiece>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.CrossNecklace);
            recipe.AddRecipe();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Material" && x.mod == "Terraria");
            if (tt != null)
            {
                // We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what language the player is using)
                // So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                // Change the tooltip text
                tt.text = "[c/00FF00:(Exotic Artifact)]";
            }
        }
        }
}
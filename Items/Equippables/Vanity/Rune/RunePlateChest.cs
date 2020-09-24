using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.Rune
{
    [AutoloadEquip(EquipType.Body)]
    public class RunePlateChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Runed Plate Mail");
            Tooltip.SetDefault("'Flashy and mysterious'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12317;
            item.rare = ItemRarityID.Orange;
            item.vanity = true;
        }

        //public override void UpdateEquip(Player player) {
        //player.buffImmune[BuffID.Poisoned] = true;
        //}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby, 5);
            recipe.AddIngredient(ItemID.GoldBar, 15);
            recipe.AddIngredient(ItemID.Silk, 25);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
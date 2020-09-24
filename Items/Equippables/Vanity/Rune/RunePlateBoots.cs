using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.Rune
{
    [AutoloadEquip(EquipType.Legs)]
    public class RunePlateBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Runed Metal Boots");
            Tooltip.SetDefault("'Built with only the finest of metals'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12314;
            item.rare = ItemRarityID.Orange;
            item.vanity = true;
        }

        //public override void UpdateEquip(Player player) {
        //player.moveSpeed += 0.5f;
        //}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby, 5);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
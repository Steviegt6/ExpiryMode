using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.Ravenous
{
    [AutoloadEquip(EquipType.Body)]
    public class RavenousChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ravenous Chestpiece");
            Tooltip.SetDefault("'Reinforced steel for all the stray bullets'");
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
            recipe.AddIngredient(ItemID.Sapphire, 5);
            recipe.AddIngredient(ItemID.SilverBar, 3);
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
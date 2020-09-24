using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.Ravenous
{
    [AutoloadEquip(EquipType.Legs)]
    public class RavenousLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ravenous Plated Leggings");
            Tooltip.SetDefault("'Can withstand even the deadliest of blows!'\n'...Just don't run too fast, it's not that durable'");
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
            recipe.AddIngredient(ItemID.Sapphire, 5);
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
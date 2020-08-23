using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpiryMode.Items.Equippables.Vanity;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ExpiryMode.Mod_;

namespace ExpiryMode.Items.Equippables.Vanity.Back
{
    [AutoloadEquip(EquipType.Back)]
    public class DyeableCape : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cape");
            Tooltip.SetDefault("Dye it for better asthetics\n'Makes you better in combat'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = 100;
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
            item.vanity = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
        }
        public override bool CanEquipAccessory(Player player, int slot)
        {
            return player.name.Contains("Ryan")
                || player.name.Contains("ryan")
                || player.name.Contains("Garou")
                || player.name.Contains("garou")
                || player.name.Contains("[DEBUG]");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

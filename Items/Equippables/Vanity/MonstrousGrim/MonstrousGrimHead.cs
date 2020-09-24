using ExpiryMode.Global_;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.MonstrousGrim
{
    [AutoloadEquip(EquipType.Head)]
    public class MonstrousGrimHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Monstrous Grim Mask");
            Tooltip.SetDefault("'Great for impersonating Expiry Devs!'\n'It's almost like it's looking at me!'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12342;
            item.rare = ExpiryRarity.VortexRarity;
            item.vanity = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
            drawAltHair = false;
        }
    }
}
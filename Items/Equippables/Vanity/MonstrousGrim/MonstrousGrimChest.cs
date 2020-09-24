using ExpiryMode.Global_;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.MonstrousGrim
{
    [AutoloadEquip(EquipType.Body)]
    public class MonstrousGrimChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Monstrous Breastplate");
            Tooltip.SetDefault("'Great for impersonating Expiry Devs!'\n'Shines green in all light.'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12317;
            item.rare = ExpiryRarity.VortexRarity;
            item.vanity = true;
        }
    }
}
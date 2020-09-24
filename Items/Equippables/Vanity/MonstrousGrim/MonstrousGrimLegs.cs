using ExpiryMode.Global_;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.MonstrousGrim
{
    [AutoloadEquip(EquipType.Legs)]
    public class MonstrousGrimLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Monstrous Grim Stompies");
            Tooltip.SetDefault("'Great for impersonating Expiry Devs!'\n'I'm fast as f**k boi!'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12314;
            item.rare = ExpiryRarity.VortexRarity;
            item.vanity = true;
        }
    }
}
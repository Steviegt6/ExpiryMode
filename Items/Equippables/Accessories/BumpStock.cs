using ExpiryMode.Global_;
using ExpiryMode.Mod_;
using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Accessories
{
    public class BumpStock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bump Stock");
            Tooltip.SetDefault("Allows for any gun to be used automatically\nIncreases all ranged damage by 18%\nMakes all guns affected to fire 20% faster\nIncreases ranged crit chance by 10%\n'I don't know how much longer I can hold this'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12317;
            item.accessory = true;
            item.rare = ExpiryRarity.Expiry;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamageMult = 1.18f;
            player.rangedCrit += 10;
            player.GetModPlayer<InfiniteSuffPlayer>().bumpStock = true;
        }
    }
}
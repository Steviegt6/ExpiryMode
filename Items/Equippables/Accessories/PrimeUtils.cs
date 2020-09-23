using Terraria;
using Terraria.ModLoader;
using ExpiryMode.Global_;
using ExpiryMode.Mod_;
using Terraria.ID;

namespace ExpiryMode.Items.Equippables.Accessories
{
    public class PrimeUtils : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Skeletron Prime's Utility");
			Tooltip.SetDefault("Makes you fire a high damaging Prime Bomb or a Prime Laser at random when firing bows\nBeware: You can hit yourself with the bombs\nDEV NOTE: Yeah, some bows don't get affected.\n'Your inner terrorist has awoken!'");
		}
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = 61283;
            item.accessory = true;
            item.rare = ExpiryRarity.Expiry;
        }
        public override void UpdateEquip(Player player) 
		{
            player.GetModPlayer<InfiniteSuffPlayer>().primeUtils = true;
            // Remember: Makes bombs/lasers fire!
		}
	}
}
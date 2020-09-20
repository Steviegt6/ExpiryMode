using Terraria.ModLoader;
using ExpiryMode.Global_;

namespace ExpiryMode.Items.Equippables.Vanity.Prismatic
{
	[AutoloadEquip(EquipType.Body)]
	public class PrismaticVest : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Prismatic Vest");
			Tooltip.SetDefault("'Great for impersonating Expiry Devs!'\n'Embrace the cool, be the cool.'");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = 12317;
			item.rare = ExpiryRarity.PrismaticRarity;
			item.vanity = true;
		}
	}
}
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Projectiles;
using ExpiryMode.Buffs.BadBuffs;
using ExpiryMode.Items.Materials;
using ExpiryMode.Global_;

namespace ExpiryMode.Items.Weapons.Swords
{
	public class RottenRaven : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Fires a Plaguebird to orbit the player."
			+"\nInflicts Radiated debuff to what it hits");
		}

		public override void SetDefaults() 
		{
			item.damage = 32;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ExpiryRarity.AcidicRarity;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileType<Plaguebird>();
			item.shootSpeed = 12f;
			
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<RadianiteBarItem>(), 12);
			recipe.AddIngredient(ItemType<RadioactiveSoulThingy>(), 5);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			target.AddBuff(BuffType<RadiatedWater>(), 120);
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
			target.AddBuff(BuffType<RadiatedWater>(), 120);

		}
    }
}
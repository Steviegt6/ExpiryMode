using ExpiryMode.Items.Materials;
using ExpiryMode.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Ammo
{
    public class RadiantBulletItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radianite Bullet");
            Tooltip.SetDefault("Stuns your enemies and gives them radiation poisoning!");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 8)); // Note: TicksPerFrame, Frames
        }

        public override void SetDefaults()
        {
            Player player = Main.player[Main.myPlayer];
            item.damage = 17;
            item.crit = 2;
            item.knockBack = 4;
            item.ammo = AmmoID.Bullet;
            item.shoot = ProjectileType<RadiantBullet>();
            item.shootSpeed = 14f;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Lime;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ProjectileType<RadiantBullet>();
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<RadianiteBarItem>());
            recipe.AddIngredient(ItemID.EmptyBullet, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
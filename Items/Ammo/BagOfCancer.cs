using ExpiryMode.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Ammo
{
    public class BagOfCancer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottomless Radianite Arrows");
            Tooltip.SetDefault("Radiate them like no one's business!");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 7)); // Note: TicksPerFrame, Frames
        }

        public override void SetDefaults()
        {
            Player player = Main.player[Main.myPlayer];
            item.damage = 13;
            item.crit = 2;
            item.knockBack = 4;
            item.ammo = AmmoID.Arrow;
            item.shoot = ProjectileType<RadiantArrow>();
            item.shootSpeed = 14f;
            item.maxStack = 999;
            item.consumable = false;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 1;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.position, Color.Chartreuse.ToVector3() * 0.55f * Main.essScale);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                // Change the tooltip text
                tt.text = "Deals your current bow's damage";
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ProjectileType<RadiantArrow>();
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<RadiantArrowItem>(), 3996);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
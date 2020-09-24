using ExpiryMode.Items.Materials;
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
    public class RadiantArrowItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radianite Arrow");
            Tooltip.SetDefault("Stuns your enemies and gives them radiation poisoning!");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 9)); // Note: TicksPerFrame, Frames
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
            item.consumable = true;
            item.rare = ItemRarityID.Lime;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                // We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what language the player is using)
                // So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
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
            recipe.AddIngredient(ItemType<RadianiteBarItem>());
            recipe.AddIngredient(ItemID.WoodenArrow, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
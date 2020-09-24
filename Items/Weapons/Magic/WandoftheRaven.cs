using ExpiryMode.Global_;
using ExpiryMode.Items.Materials;
using ExpiryMode.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Weapons.Magic
{
    public class WandoftheRaven : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of the Raven");
            Tooltip.SetDefault("Emits a spread of birds from your cursor.");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.magic = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.value = 10000;
            item.rare = ExpiryRarity.AcidicRarity;
            item.UseSound = SoundID.Item73;
            item.autoReuse = true;
            item.shoot = ProjectileType<BiohazardBird>();
            item.shootSpeed = 12f;
            item.crit = 14;
            item.mana = 16;
            item.reuseDelay = 8;
            Item.staff[item.type] = true;
        }

        /*public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix);
            GameShaders.Armor[GameShaders.Armor].Apply()
            return true;
        }
        public override void PostDrawTooltipLine(DrawableTooltipLine line)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin();  // stevie, dont mind this, working on my shader rarity
        }*/

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            float numberProjectiles = 5f;
            float rotation = MathHelper.ToRadians(180f);
            int i = 0;
            while (i < numberProjectiles)
            {
                Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(speedX, speedY), MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
                i++;
            }
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 offSetAngle = Main.MouseWorld + new Vector2(-18, -18);
            for (int j = 0; j <= 25; j++)
            {
                dust = Main.dust[Dust.NewDust(offSetAngle, 40, 40, 163, 0f, 0f, 0, new Color(0, 255, 92), 0.2631579f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(59, Main.LocalPlayer);
                dust.fadeIn = 1.58f;
            }

            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<RadianiteBarItem>(), 8);
            recipe.AddIngredient(ItemType<RadioactiveSoulThingy>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
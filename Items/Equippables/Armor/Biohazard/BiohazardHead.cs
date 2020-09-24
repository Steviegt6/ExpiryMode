using ExpiryMode.Buffs.BadBuffs;
using ExpiryMode.Global_;
using ExpiryMode.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Equippables.Armor.Biohazard
{
    [AutoloadEquip(EquipType.Head)]
    public class BiohazardHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reinforced Hazmat Mask");
            Tooltip.SetDefault("Allows breathing in space\n'Fresh air > Breathing Despair'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12342;
            item.rare = ExpiryRarity.AcidicRarity;
            item.defense = 10;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
            drawAltHair = false;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return legs.type == ItemType<BiohazardLegs>() && body.type == ItemType<BiohazardBody>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Completely Immune to all radiation effects\n5% damage increase to all damage types";
            player.allDamageMult = 1.05f;
            player.buffImmune[BuffType<AbsoluteDoom>()] = true;
            player.buffImmune[BuffType<RadiatedWater>()] = true;
            player.buffImmune[BuffType<DoomLess>()] = true;
            player.ClearBuff(BuffType<DoomLess>());
            player.ClearBuff(BuffType<AbsoluteDoom>());
            player.ClearBuff(BuffType<RadiatedWater>());
        }

        public override void UpdateEquip(Player player)
        {
            player.buffImmune[BuffType<CantBreathe>()] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 8);
            recipe.AddIngredient(ItemType<RadianiteBarItem>(), 12);
            recipe.AddIngredient(ItemType<RadioactiveSoulThingy>(), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
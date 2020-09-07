using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Equippables.Vanity.Ravenous
{
	[AutoloadEquip(EquipType.Head)]
	public class RavenousHead : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ravenous Tailed Helm");
			Tooltip.SetDefault("'This ponytail ain't for show, kid'\n'Something to cover that hair of yours'");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 12342;
            item.rare = ItemRarityID.Orange;
			item.vanity = true;
		}

        //public override bool IsArmorSet(Item head, Item body, Item legs) {
        //return body.type == ItemType<EmeraldBreastplate>() && legs.type == ItemType<EmeraldBoots>();
        //}
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
            drawAltHair = false;
        }
        public override bool DrawHead()
        {
            return false;
        }
        public override bool IsVanitySet(int head, int body, int legs)
        {
            return head == mod.GetEquipSlot("RavenousHead", EquipType.Head) && body == mod.GetEquipSlot("RavenousChest", EquipType.Body) && legs == mod.GetEquipSlot("RavenousLegs", EquipType.Legs);
        }
        public override void UpdateVanitySet(Player player)
		{
        }
        public override void ArmorSetShadows(Player player)
        {
			player.armorEffectDrawOutlines = true;
        }
        /*public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "25% faster melee speed and 10% more melee damage";
            // Here are the individual weapon class bonuses.
            player.meleeDamage += 0.1f;
            player.meleeSpeed = 1.25f;
        }*/
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.AddIngredient(ItemID.SilverBar, 3);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
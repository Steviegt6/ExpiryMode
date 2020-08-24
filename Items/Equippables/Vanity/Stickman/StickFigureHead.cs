using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.Stickman
{
	[AutoloadEquip(EquipType.Head)]
	public class StickFigureHead : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stickman Head");
			Tooltip.SetDefault("Unobtainable (Legitamately)");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 12342;
            item.rare = ItemRarityID.Orange;
			item.vanity = true;
		}
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
            return head == mod.GetEquipSlot("StickFigureHead", EquipType.Head) && body == mod.GetEquipSlot("StickFigureBody", EquipType.Body) && legs == mod.GetEquipSlot("StickFigureLegs", EquipType.Legs);
        }
	}
}
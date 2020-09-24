using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.Stickman
{
    [AutoloadEquip(EquipType.Body)]
    public class StickFigureBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stickman Body");
            Tooltip.SetDefault("Unobtainable (Legitamately)");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12317;
            item.rare = ItemRarityID.Orange;
            item.vanity = true;
        }

        public override bool DrawBody()
        {
            return false;
        }
    }
}
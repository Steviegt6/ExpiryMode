using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.Stickman
{
    [AutoloadEquip(EquipType.Legs)]
    public class StickFigureLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stickman Legs");
            Tooltip.SetDefault("Unobtainable (Legitamately)");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12314;
            item.rare = ItemRarityID.Orange;
            item.vanity = true;
        }
        public override bool DrawLegs()
        {
            return false;
        }
    }
}
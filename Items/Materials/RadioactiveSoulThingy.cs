using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Materials
{
    public class RadioactiveSoulThingy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calamitous Contagion");
            Tooltip.SetDefault("'Eminates an offsetting aura'");
            ItemID.Sets.ItemNoGravity[item.type] = true;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6)); // NOTE: TicksPerFrame, Frames
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 999;
        }
    }
}
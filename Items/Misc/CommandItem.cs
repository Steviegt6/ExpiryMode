using Terraria.ModLoader;

namespace ExpiryMode.Items.Misc
{
    public class CommandItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("CMD Machine");
            Tooltip.SetDefault("Allows you to use debug commands");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 28;
        }
    }
}
using ExpiryMode.Global_;
using ExpiryMode.Mod_;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Vanity.Prismatic
{
    [AutoloadEquip(EquipType.Body)]
    public class PrismaticVest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Vest");
            Tooltip.SetDefault("'Great for impersonating Expiry Devs!'\n'Embrace the cool, be the cool.'");
        }

        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            color = Main.DiscoColor;
        }

        public override bool IsVanitySet(int head, int body, int legs)
        {
            return true;
        }

        public override void PreUpdateVanitySet(Player player)
        {
            Lighting.AddLight(player.Center, Main.DiscoColor.ToVector3() * 0.55f * Main.essScale);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<InfiniteSuffPlayer>().accPrisBody = true;
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 12317;
            item.rare = ExpiryRarity.PrismaticRarity;
            item.vanity = true;
        }
    }
}
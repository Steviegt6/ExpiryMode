using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Waters
{
    public class RadiantWater : ModWaterStyle
    {
        public override bool ChooseWaterStyle()
        {
            return Main.bgStyle == mod.GetSurfaceBgStyleSlot("RadiantBackground"); // When this background is enabled, use this custom water style
        }

        public override int ChooseWaterfallStyle()
        {
            return mod.GetWaterfallStyleSlot("RadiantWaterfall");   // Spritesheet grabber for the waterfall
        }

        public override int GetSplashDust()
        {
            return DustType<RadiantWaterSplash>(); // This gets the dust that emits when you jump INTO the water
        }

        public override int GetDropletGore()
        {
            return mod.GetGoreSlot("Waters/RadiantWater_Block"); // The droplet that comes out of ceilings
        }

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0.53725490196f;
            g = 0.63529411764f;
            b = 0.01176470588f;
        }

        public override Color BiomeHairColor()
        {
            return Color.Green;
        }
    }
}
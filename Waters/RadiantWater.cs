using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
 
namespace ExpiryMode.Waters
{
    public class RadiantWater : ModWaterStyle
    {
        public override bool ChooseWaterStyle()
        {
            return Main.bgStyle == mod.GetSurfaceBgStyleSlot("RadiantBackground");    //this is where u choose where the custom water/waterfalls will appear. it will appear in base of backgrounds so add your surface background name.
        }
 
        public override int ChooseWaterfallStyle()
        {
            return mod.GetWaterfallStyleSlot("RadiantWaterfall");   //this is the waterfall style
        }
 
        public override int GetSplashDust()
        {
            return mod.DustType("RadiantWaterSplash");   //this is the water splash dust
        }
 
        public override int GetDropletGore()
        {
            return mod.GetGoreSlot("Waters/RadiantWater_Block");     //this is the water droplet
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
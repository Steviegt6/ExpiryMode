using ExpiryMode.Items.Blocks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Tiles
{
    public class RadianiteOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ItemType<RadianiteOreItem>();
            AddMapEntry(new Color(0, 255, 0));
            soundType = SoundID.Tink;
            minPick = 100;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
            //Lighting.AddLight(16, 50, 100, 50 , 10);
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(new Vector2(i, j).ToWorldCoordinates(), 16, 16, DustID.Smoke, 0, 0, 0, new Color(148, 172, 2), 1);
            }
            else
            {
                Dust.NewDust(new Vector2(i, j).ToWorldCoordinates(), 16, 16, DustID.Smoke, 0, 0, 0, new Color(148, 172, 2), 1);
            }
            return false;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.19607843137f;
            g = 0.88235294117f;
            b = 0.19607843137f;
        }
    }
}
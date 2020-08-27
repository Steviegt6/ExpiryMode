using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Tiles
{
	public class IrridiatedWood : ModTile
	{
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ItemType<Items.Blocks.IrridiatedWood>();
            AddMapEntry(new Color(50, 50, 50));
            soundType = SoundID.Dig ;
            minPick = 100;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
        }
        public override bool CreateDust(int i, int j, ref int type)
        {
            if (Main.rand.Next(1) == 0)
            {
                Dust.NewDust(new Vector2(i, j).ToWorldCoordinates(), 16, 16, DustID.Smoke, 0, 0, 0, new Color(100, 100, 100), 1);
            }
            else
            {
                Dust.NewDust(new Vector2(i, j).ToWorldCoordinates(), 16, 16, DustID.Smoke, 0, 0, 0, new Color(150, 150, 150), 1);
            }
            return false;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.0f;
			g = 0.0f;
			b = 0.0f;
		}
	}
}
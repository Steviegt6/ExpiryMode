using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Items.Blocks;

namespace ExpiryMode.Tiles
{
	public class RottenGrass : ModTile
	{
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
			Main.tileMerge[Type][TileType<DoomGravel>()] = true;
			Main.tileMerge[TileType<DoomGravel>()   ][Type] = true;
            drop = ItemType<RadiantDirtItem>();
            AddMapEntry(new Color(40, 150, 40));
            soundType = SoundID.Dig;
            minPick = 100;
            //Lighting.AddLight(16, 50, 100, 50 , 10);
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
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (!fail && tile.type == TileType<RottenGrass>())
            {
                tile.type = (ushort)TileType<RadiantDirt>();
            }
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.0f;
			g = 0.0f;
			b = 0.0f;
		}
	}
}
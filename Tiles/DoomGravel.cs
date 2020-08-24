using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using ExpiryMode.Tiles.Trees;

namespace ExpiryMode.Tiles
{
	public class DoomGravel : ModTile
	{
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("DoomGravel");
            AddMapEntry(new Color(75, 125, 75));
            soundType = SoundID.Tink;
            minPick = 50;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
        }
        public override bool CreateDust(int i, int j, ref int type)
        {
            // This method is called entirely on the fact that the block is being hit with a pickaxe, or is destroyed by an explosive
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
        public override int SaplingGrowthType(ref int style) // This method is not necessarily helping me, as my trees do NOT work yet.
        {
            style = 0;
            return ModContent.TileType<RottenSapling>();
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) // Modify the light that this tile produces, if any at all
		{
			r = 0.0f;
			g = 0.0f;
			b = 0.0f;
		}
	}
}
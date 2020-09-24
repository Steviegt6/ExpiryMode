using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ExpiryMode.Tiles
{
    public class RottenTree : ModTree
    {
        private Mod mod
        {
            get
            {
                return ModLoader.GetMod("InfiniteSuffering");
            }
        }

        public override int DropWood()
        {
            return mod.ItemType("IrridiatedWood");
        }

        public override Texture2D GetTexture()
        {
            return mod.GetTexture("Tiles/Trees/RottenTreeTile");
        }

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            return mod.GetTexture("Tiles/Trees/RottenTree_Tops");
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return mod.GetTexture("Tiles/Trees/RottenTree_Branches");
        }
    }
}
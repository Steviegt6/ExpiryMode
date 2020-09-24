using ExpiryMode.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExpiryMode.Tiles
{
    public class RadianiteBar : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(0, 255, 0), Language.GetText("Radianite Bar"));
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            //TileObjectData.addTile(Type);
        }

        public override bool Drop(int i, int j)
        {
            if (Main.tile[i, j].frameX / 18 == 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<RadianiteBarItem>(), 1, false, 0, false, false);
            }
            return base.Drop(i, j);
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
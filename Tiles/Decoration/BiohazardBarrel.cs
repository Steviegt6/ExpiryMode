using ExpiryMode.Items.Decoration;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Tiles.Decoration
{
    public class BiohazardBarrel : ModTile
    {
        public override void SetDefaults()
        {
            soundType = SoundLoader.customSoundType;//(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Clank"));
            soundStyle = mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/Clank");
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = false;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            AddMapEntry(new Color(255, 255, 0), Language.GetText("Biohazard Barrel"));
            //AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            TileObjectData.addTile(Type);
            //adjTiles = new int[] { TileID.WorkBenches };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                50,
                56
            };
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            return false;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 50, 56, ItemType<BiohazardContainer>(), 1, false, 0, false, false);
        }

        public override bool Drop(int i, int j)
        {
            if (Main.tile[i, j].frameX / 18 == 0)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemType<BiohazardContainer>(), 1, false, 0, false, false);
            }
            return base.Drop(i, j);
        }
    }
}
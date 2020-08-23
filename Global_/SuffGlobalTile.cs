using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Items.Materials;
using Microsoft.Xna.Framework;

namespace ExpiryMode.Global_
{
	public class SuffGlobalTile : GlobalTile
	{
        public override void SetDefaults()
        {
        }
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            /*Player player = Main.player[Main.myPlayer];
            Tile tile = Main.tile[i, j];
            //NPC npc = Main.npc[type];
            if (player.ZoneDesert && tile.type == TileID.Pots)
            {
                NPC.NewNPC((int)player.position.X, (int)player.position.X, NPCID.BlueSlime);
                Main.NewText("this is a check");
            }*/
        }
    }
}

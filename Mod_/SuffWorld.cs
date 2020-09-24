using ExpiryMode.Tiles;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Mod_
{
    public class SuffWorld : ModWorld
    {
        public static int playerDeathCount;
        public static bool ExpiryModeIsActive = false;
        public static int DoomBlockCount = 0;

        public override void Initialize()
        {
            ExpiryModeIsActive = false;
            playerDeathCount = 0;
        }

        public override void Load(TagCompound tag)
        {
            ExpiryModeIsActive = tag.GetBool("ExpiryModeIsActive");
        }

        public override TagCompound Save()
        {
            return new TagCompound
            { {  "ExpiryModeIsActive", ExpiryModeIsActive } };
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("DoomGen", delegate (GenerationProgress progress)
            {
                progress.Message = "Your doom is generating...";
                for (int i = 0; i < Main.maxTilesX / 2400; i++)
                {
                    int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 500);
                    int Yvalue = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.worldSurfaceHigh /*Main.maxTilesY - 600*/ );
                    int XvalueMid = Xvalue - 75;
                    int YvalueMid = Yvalue - 75;
                    Tile tile = Framing.GetTileSafely(Xvalue, Yvalue);
                    if (tile.active() && tile.type == TileID.Grass)
                    {
                        WorldGen.TileRunner(XvalueMid, YvalueMid, WorldGen.genRand.Next(300, 700), 1, TileType<RottenGrass>(), false, 0f, 0f, true, true);
                    }
                    {
                        WorldGen.TileRunner(XvalueMid, YvalueMid, WorldGen.genRand.Next(300, 700), 1, TileType<DoomGravel>(), false, 0f, 0f, true, true);
                        WorldGen.digTunnel(Xvalue + 400, Yvalue + 400, 0f, 0f, WorldGen.genRand.Next(15, 18), WorldGen.genRand.Next(14, 17), false);
                    }
                }
            }));
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            DoomBlockCount = tileCounts[TileType<DoomGravel>()];
        }
    }

    public class RadiantDirt : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            if (ShiniesIndex != -1)
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Radiant Dirt Generation", RadiantDirtGen));
        }

        private void RadiantDirtGen(GenerationProgress progress)
        {
            progress.Message = "Dirt inside your doom...";

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * .008); k++)
            {
                int x = WorldGen.genRand.Next(50, Main.maxTilesX - 500);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, Main.maxTilesY - 600);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.active() && tile.type == TileType<DoomGravel>())
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(5, 7), ModContent.TileType<Tiles.RadiantDirt>());
                }
            }
        }
    }

    public class Radianite : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            if (ShiniesIndex != -1)
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Radiant OreGen", RadianiteOreGen));
        }

        private void RadianiteOreGen(GenerationProgress progress)
        {
            progress.Message = "Generating ores that cause doom...";

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * .0007); k++)
            {
                int x = WorldGen.genRand.Next(50, Main.maxTilesX - 500);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, Main.maxTilesY - 600);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.active() && tile.type == TileType<DoomGravel>() || tile.active() && tile.type == TileType<Tiles.RadiantDirt>())
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(5, 7), ModContent.TileType<RadianiteOre>());
                }
            }
        }

        // TODO: This stupid ass shit won't save. Get this thing's gay ass to work.
        public override void Load(TagCompound tag)
        {
            Main.player[Main.myPlayer].GetModPlayer<DeathCountPlayer>().playerDeathCount = tag.GetInt("playerDeathCount");
        }

        public override TagCompound Save()
        {
            if (Main.gameMenu)
            {
                Main.sunTexture = GetTexture("Terraria/Sun");
                Main.rainTexture = GetTexture("Terraria/Rain");
                return null;
            }
            return new TagCompound
            {
                {"playerDeathCount", Main.player[Main.myPlayer].GetModPlayer<DeathCountPlayer>().playerDeathCount}
            };
        }
    }
}
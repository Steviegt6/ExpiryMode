using Terraria.ModLoader;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using static Terraria.Main;
using System;
using Terraria.Localization;
using Terraria.ID;
using ExpiryMode.Items.Blocks;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.Cil;
using ReLogic.Graphics;
using System.Diagnostics;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Items.Misc;
using Mono.Cecil.Cil;
using static ExpiryMode.Mod_.SuffWorld;
using Terraria.ModLoader.Audio;
using System.Threading;
using System.Reflection;
using Terraria.ModLoader.Config;

namespace ExpiryMode.Mod_
{
    public class ExpiryModeMod : Mod
    {
        private bool stopTitleMusic;
        private ManualResetEvent titleMusicStopped;
        private int customTitleMusicSlot;
        public ExpiryModeMod() { GetInstance<ExpiryModeMod>(); }
        private void TitleMusicIL(ILContext il)
        {
            ILCursor ilcursor = new ILCursor(il);
            ILCursor ilcursor2 = ilcursor;
            MoveType moveType = (MoveType)2;
            Func<Instruction, bool>[] array = new Func<Instruction, bool>[1];
            array[0] = ((Instruction i) => ILPatternMatchingExt.MatchLdfld<Main>(i, "newMusic"));
            ilcursor2.GotoNext(moveType, array);
            ilcursor.EmitDelegate<Func<int, int>>(delegate (int newMusic)
            {
                if (newMusic != 6)
                {
                    return newMusic;
                }
                return customTitleMusicSlot;
            });
        }
        private void MenuMusicSet()
        {
            if (GetInstance<ExpiryConfig>().MusicChange)
            {
                customTitleMusicSlot = GetSoundSlot((SoundType)51, "Sounds/Music/CreepyMusic");
                IL.Terraria.Main.UpdateAudio += new ILContext.Manipulator(TitleMusicIL);
            }
        }
        public override void PostSetupContent()
        {
            if (ModLoader.GetMod("TerrariaOverhaul") == null)
            {
                MenuMusicSet();
            }
        }
        public override void Close()
        {
            int soundSlot = GetSoundSlot((SoundType)51, "Sounds/Music/CreepyMusic");
            if (Utils.IndexInRange(music, soundSlot))
            {
                Music music = Main.music[soundSlot];
                if (music != null && music.IsPlaying)
                {
                    Main.music[soundSlot].Stop((Microsoft.Xna.Framework.Audio.AudioStopOptions)1);
                }
            }
            base.Close();
        }
        internal static void HookMenuSplash(ILContext il)
        {
            var c = new ILCursor(il).Goto(0);
            if (!c.TryGotoNext(i => i.MatchLdsfld(typeof(Main).GetField("dayTime"))))
                return;
            c.Emit(OpCodes.Call, typeof(ExpiryModeMod).GetMethod("DrawSplashText"));
        }
        public static void DrawSplashText()
        {
            for (int textIndex = 0; textIndex < 5; textIndex++)
            {
                Color color = Color.Black;
                if (textIndex == 4)
                {
                    byte b = (byte)((byte.MaxValue + tileColor.R * 2) / 3);
                    color = new Color(b, b, b, 255);
                    color.R = (byte)((255 + color.R) / 2);
                    color.G = (byte)((255 + color.R) / 2);
                    color.B = (byte)((255 + color.R) / 2);
                }
                color.A = (byte)(color.A * 0.3f);
                int xOffset = 0;
                int yOffset = 0;
                if (textIndex == 0)
                {
                    xOffset = -2;
                }
                if (textIndex == 1)
                {
                    xOffset = 2;
                }
                if (textIndex == 2)
                {
                    yOffset = -2;
                }
                if (textIndex == 3)
                {
                    yOffset = 2;
                }
                string text5 = $"Join the Expiry Mode discord server!";
                string text6 = $"The discord server is a nice place to hang out and discuss\nthings about this mod. For now, there is no wiki, but in the\nnear future, there will be one! Click on the top line to join my\ndiscord server!";
                string text7 = $"Expiry Mode v{ModLoader.GetMod("ExpiryMode").Version}";
                Vector2 origin2 = fontMouseText.MeasureString(text5);
                origin2.X *= 0.5f;
                origin2.Y *= 0.5f;
                spriteBatch.DrawString(fontMouseText, text7, new Vector2(screenWidth + xOffset - origin2.X + 120f, screenHeight - origin2.Y * 2 + yOffset - 12f), color, 0f, origin2, 1f, SpriteEffects.None, 0f);
                if (ModLoader.GetMod("HamstarHelpers") == null)
                {
                    spriteBatch.DrawString(fontMouseText, text6, new Vector2(screenWidth + xOffset - origin2.X - 210f, origin2.Y + yOffset + 40f), color, 0f, origin2, 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.DrawString(fontMouseText, text6, new Vector2(screenWidth + xOffset - origin2.X - 450f, origin2.Y + yOffset + 40f), color, 0f, origin2, 1f, SpriteEffects.None, 0f);
                }
                Rectangle discordLink = new Rectangle((int)(screenWidth - origin2.X * 2 - 108), 0, (int)(origin2.X * 2), (int)(origin2.Y * 2));
                Rectangle discordLinkFurtherOut = new Rectangle((int)(screenWidth - origin2.X * 2 - 375), 0, (int)(origin2.X * 2), (int)(origin2.Y * 2));
                if (discordLink.Contains(MouseScreen.ToPoint()) && ModLoader.GetMod("HamstarHelpers") == null)
                {
                    if (textIndex == 4)
                    {
                        color = new Color(255, 255, 0);
                        if (mouseLeft && mouseLeftRelease)
                        {
                            Process.Start("https://discord.gg/nnjjqbn");
                        }
                    }
                }
                if (discordLinkFurtherOut.Contains(MouseScreen.ToPoint()) && ModLoader.GetMod("HamstarHelpers") != null)
                {
                    if (textIndex == 4)
                    {
                        color = new Color(255, 255, 0);
                        if (mouseLeft && mouseLeftRelease)
                        {
                            Process.Start("https://discord.gg/nnjjqbn");
                        }
                    }
                }
                if (ModLoader.GetMod("HamstarHelpers") == null)
                {
                    spriteBatch.DrawString(fontMouseText, text5, new Vector2(screenWidth + xOffset - origin2.X - 105f, origin2.Y + yOffset + 10f), color, 0f, origin2, 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.DrawString(fontMouseText, text5, new Vector2(screenWidth + xOffset - origin2.X - 375f, origin2.Y + yOffset + 10f), color, 0f, origin2, 1f, SpriteEffects.None, 0f);
                }
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "BiomeSouls", new int[] { ItemID.SoulofLight, ItemID.SoulofNight });
            RecipeGroup.RegisterGroup("ExpiryMode:BiomeSouls", group);
            if (RecipeGroup.recipeGroupIDs.ContainsKey("Wood"))
            {
                int num1 = RecipeGroup.recipeGroupIDs["Wood"];
                group = RecipeGroup.recipeGroups[num1];
                group.ValidItems.Add(ModContent.ItemType<IrridiatedWood>());
            }
        }
        public static ModHotKey ShiftIsPressed;
        public override void AddRecipes() { }
        public override void PostUpdateEverything() { }
        public override void Unload()
        {
            ShiftIsPressed = null;
            IL.Terraria.Main.UpdateAudio -= new ILContext.Manipulator(TitleMusicIL);
            customTitleMusicSlot = 6;
            Close();
            ManualResetEvent manualResetEvent = titleMusicStopped;
            if (manualResetEvent != null)
            {
                manualResetEvent.Set();
            }
            titleMusicStopped = null;
        }
        public override void Load()
        {
            IL.Terraria.Main.DrawMenu += HookMenuSplash;
            if (!dedServ)
            {
                On.Terraria.Lang.GetRandomGameTitle += Lang_GetRandomGameTitle;
                chTitle = true;
            }
            ShiftIsPressed = RegisterHotKey("View Extra Tooltip Details", "LeftAlt");
            if (!dedServ)
            {
                Filters.Scene["InfniteSuffering:RadiatedBiomeSky"] = new Filter(new ScreenShaderData("FilterTower").UseColor(0.0f, 0.0f, 0.0f).UseOpacity(0.66f), EffectPriority.Low);
                SkyManager.Instance["InfniteSuffering:RadiatedBiomeSky"] = new RadiatedSky();
            }
        }

        private string Lang_GetRandomGameTitle(On.Terraria.Lang.orig_GetRandomGameTitle orig)
        {
            string ScreenLoadChance = "tModLoader: Terraria";

            switch (rand.Next(7))
            {
                default:
                    ScreenLoadChance = "tModLoader: Ever heard of a guy called pollen__?";
                    break;
                case 1:
                    ScreenLoadChance = "tModLoader: You've Been Distracted!";
                    break;
                case 2:
                    ScreenLoadChance = "tModLoader: Close the application";
                    break;
                case 3:
                    ScreenLoadChance = "tStandalone: Wait, wrong app";
                    break;
                case 4:
                    ScreenLoadChance = "tModLoader: what.ogg is the best song";
                    break;
                case 5:
                    ScreenLoadChance = "tModLoader_1.4.0.5: Wait, wrong version";
                    break;
                case 6:
                    if (ModLoader.GetMod("CalamityMod") != null)
                        ScreenLoadChance = "tModLoader: Calamity isn't really that good";
                    break;
            }
            return ScreenLoadChance;
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            Player player = Main.player[myPlayer];
            if (gameMenu)
                musicVolume = .5f;
            if (gameMenu)
            {
                return;
            }
            if (Main.player[myPlayer].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/DoomMusic");
                priority = MusicPriority.BiomeHigh;
            }
            if (stopTitleMusic || (!gameMenu && customTitleMusicSlot != 6 && ActivePlayerFileData != null && ActiveWorldFileData != null))
            {
                if (!stopTitleMusic || !GetInstance<ExpiryConfig>().MusicChange)
                {
                    music = 6;
                }
                else
                {
                    stopTitleMusic = true;
                }
                if (GetInstance<ExpiryConfig>().MusicChange)
                {

                }
                customTitleMusicSlot = 6;
                Music music2 = GetMusic("Sounds/Music/CreepyMusic");
                if (music2.IsPlaying)
                {
                    music2.Stop((Microsoft.Xna.Framework.Audio.AudioStopOptions)1);
                }
                titleMusicStopped.Set();
                stopTitleMusic = false;
            }
        }
        /// <summary>
        /// Saves the config of the said mod config file.
        /// </summary>
        /// <param name="expiryConfig"></param>
        internal static void SaveConfig(ExpiryConfig expiryConfig)
        {
            MethodInfo method = typeof(ConfigManager).GetMethod("Save", BindingFlags.Static | BindingFlags.NonPublic);
            if (method != null)
            {
                method.Invoke(null, new object[]
                {
                    GetInstance<ExpiryConfig>()
                });
                return;
            }
        }
        public override void PreSaveAndQuit()
        {
            if (ModLoader.GetMod("TerrariaOverhaul") == null || ModLoader.GetMod("CalamityModMusic") == null)
            {
                MenuMusicSet(); // Mirsario, you suck ass. Your mod takes all priority. So do you, Fabsol.
            }
            else
            {
                return;
            }
        }
        public override void ModifyLightingBrightness(ref float scale)
        {
            Player player = Main.player[myPlayer];
            if (GetInstance<ExpiryConfig>().MakeBiomeDark)
            {
                if (Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated && !dayTime)
                {
                    scale = .75f;
                }
                if (!dayTime && !Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
                {
                    scale = .75f;
                }
                if (dayTime && Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
                {
                    scale = .85f;
                }
                if (raining && player.ZoneSnow)
                {
                    scale = .75f;
                }
            }
        }
        /// <summary>
        /// This caused me too much pain (please use base.Close() next time)
        /// </summary>
        //public sealed override void Close()
        //{
            // You know, I spent 7 hours trying to fix an issue with my mod... https://cdn.discordapp.com/attachments/296056831514509312/738246557367009391/f0531c90ebb76dfe36d1dfee5b46852d.gif?comment=@everyone / https://cdn.discordapp.com/attachments/701182443537039390/749117222584189088/afoeeee.png
            //base.Close();
            // As you know, I'm Kind of a gamer
        //}
    }
    /// <summary>
    /// Use this command ingame to kill yourself if you have the debugging item in your inventory.
    /// </summary>
    public class KillCommand : ModCommand
    {
        public override CommandType Type
            => CommandType.Chat;

        public override string Command
            => "kill";

        public override string Usage
            => "/kill";

        public override string Description
            => "Kill yourself";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();
            Player player = Main.player[myPlayer];
            if (!player.HasItem(ItemType<CommandItem>()))
                NewText("This command can only be used while debugging!", Color.Red);
            if (player.HasItem(ItemType<CommandItem>()))
            {
                if (rand.Next(8) == 0)
                {
                    player.KillMe(PlayerDeathReason.ByCustomReason($"{player.name} couldn't take it anymore."), player.statLife, 1);
                }
                else
                {
                    player.KillMe(PlayerDeathReason.ByCustomReason($"{player.name} committed suicide."), player.statLife, 1);
                }
            }
        }
        public class ItemCommand : ModCommand
        {
            public override CommandType Type
                => CommandType.Chat;

            public override string Command
                => "hurt";

            public override string Usage
                => "/hurt <damage>";

            public override string Description
                => "Hurt yourself for any amount of damage";

            public override void Action(CommandCaller caller, string input, string[] args)
            {
                Player player = Main.player[myPlayer];
                var damageAmount = args[0];
                if (!int.TryParse(args[0], out int type))
                {
                    if (type == 0)
                    {
                        throw new UsageException($"{damageAmount} is not a valid integer.");
                    }
                }

                int damage = 1;
                if (args.Length >= 2)
                {
                    damage = int.Parse(args[1]);
                }
                if (!player.HasItem(ItemType<CommandItem>()))
                {
                    NewText("This command can only be used while debugging!", Color.Red);
                }
                if (player.HasItem(ItemType<CommandItem>()))
                {
                    caller.Player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} hurt themself a bit too much."), type, 0, false, false, false, -1);
                }
            }
        }
        /// <summary>
        /// Enables and disables Expiry Mode upon use with the debugging item in your inventory.
        /// </summary>
        public class ToggleExpiry : ModCommand
        {
            public override CommandType Type
                => CommandType.Chat;

            public override string Command
                => "em_toggle";

            public override string Usage
                => "/em_toggle";

            public override string Description
                => "Toggles Expiry Mode (Debug Command)";

            public override void Action(CommandCaller caller, string input, string[] args)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ResetColor();
                Player player = Main.player[myPlayer];
                if (!player.HasItem(ItemType<CommandItem>()))
                    NewText("This command can only be used while debugging!", Color.Red);
                if (player.HasItem(ItemType<CommandItem>()) && ExpiryModeIsActive)
                {
                    ExpiryModeIsActive = false;
                    NewText("Expiry Mode has successfully been disabled.", Color.Orange);
                }
                else if (player.HasItem(ItemType<CommandItem>()) && !ExpiryModeIsActive)
                {
                    ExpiryModeIsActive = true;
                    NewText("Expiry Mode has successfully been enabled.", Color.Orange);
                }
            }
            internal const string noteForPeopleWhoSeeThisCode = "This mod definitely does not have the greatest code, but it seems to have a TON of 'if' statements. If you see this then"
        + "\n you are a good observer.";
        }
    }
}

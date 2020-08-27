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
using System.Net;

namespace ExpiryMode.Mod_
{
    //TODO: Rotting away debuff lasts forever (client side) after leaving. (until death)
    //TODO: MAKE DISCORD APPEAR AS UI IN THE MENU
    public class ExpiryModeMod : Mod
    {
        public static string CurrentVersion = "";
        public static string ModVersion;
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        internal static void HookMenuSplash(ILContext il)
        {
            var c = new ILCursor(il).Goto(0);
            if (!c.TryGotoNext(i => i.MatchLdsfld(typeof(Main).GetField("dayTime"))))
                return; // Patch unable to be applied
                        //c.Index--;
                        //c.Emit(Ldfld, typeof(Main).GetField("logoScale"));
            c.Emit(Mono.Cecil.Cil.OpCodes.Call, typeof(ExpiryModeMod).GetMethod("DrawSplashText")); // Use reflection to pass the method
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
                if (ModLoader.GetMod("HamstarHelpers") == null)
                {
                    spriteBatch.DrawString(fontMouseText, text7, new Vector2(screenWidth + xOffset - origin2.X + 120f, screenHeight - origin2.Y * 2 + yOffset - 12f), color, 0f, origin2, 1f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(fontMouseText, text6, new Vector2(screenWidth + xOffset - origin2.X - 210f, origin2.Y + yOffset + 40f), color, 0f, origin2, 1f, SpriteEffects.None, 0f);
                }
                else if (ModLoader.GetMod("HamstarHelpers") != null)
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
                else if (ModLoader.GetMod("HamstarHelpers") != null)
                {
                    spriteBatch.DrawString(fontMouseText, text5, new Vector2(screenWidth + xOffset - origin2.X - 375f, origin2.Y + yOffset + 10f), color, 0f, origin2, 1f, SpriteEffects.None, 0f);
                }
            }
        }
        public override void Close()
        {
            // Fix a tModLoader bug.
            var slots = new int[] { GetSoundSlot(SoundType.Music, "Sounds/Music/DoomMusic"), GetSoundSlot(SoundType.Music, "Sounds/Custom/Pop") };
            foreach (var slot in slots) // Other mods crashing during loading can leave Main.music in a weird state.
            {
                if (music.IndexInRange(slot) && music[slot]?.IsPlaying == true)
                {
                    music[slot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.AsAuthored);
                }
            }

            base.Close();
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
        public ExpiryModeMod() { }
        public override void AddRecipes() { }
        public override void PostUpdateEverything() { if (myPlayer < 0) return; }
        public override void Unload() 
        { 
            ShiftIsPressed = null; 
            ModVersion = null;
        }
        public override void Load()
        {

            /*ModVersion = "v" + Version.ToString().Trim();

            //Goes out and grabs the version that the mod browser has
            using (WebClient client = new WebClient())
            {
                if (CheckForInternetConnection())
                {
                    //Parsing the data we need from the api
                    var json = client.DownloadString("http://javid.ddns.net/tModLoader/tools/modinfo.php?modname=ExpiryMode");
                    json.ToString().Trim();
                    ExpiryModeMod.CurrentVersion = json;
                    client.Dispose();
                }
            }*/
            IL.Terraria.Main.DrawMenu += HookMenuSplash;
            //Process.Start("https://discord.gg/pT2BzSG");
            string ScreenLoadChance = "tModLoader: This is getting repetitive";

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
                    ScreenLoadChance = "tStandalone: Wait, wrong mod";
                    break;
                case 4:
                    ScreenLoadChance = "tModLoader: what.ogg is the best song";
                    break;
                case 5:
                    ScreenLoadChance = "tModLoader_1.4.0.5: Wait, wrong version";
                    break;
                case 6:
                    if (ModLoader.GetMod("rterrariatod") != null)
                        ScreenLoadChance = "tModLoader: r/Terraria Mod is not that cool";
                    break;
            }
            ReLogic.OS.Platform.Current.SetWindowUnicodeTitle(instance.Window, ScreenLoadChance);
            ShiftIsPressed = RegisterHotKey("View Extra Tooltip Details", "LeftAlt");
            if (!Main.dedServ)
            {
                Filters.Scene["InfniteSuffering:RadiatedBiomeSky"] = new Filter(new ScreenShaderData("FilterTower").UseColor(0.0f, 0.0f, 0.0f).UseOpacity(0.33f), EffectPriority.Medium);
                SkyManager.Instance["InfniteSuffering:RadiatedBiomeSky"] = new RadiatedSky();
            }
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            Player player = Main.player[myPlayer];
            if (gameMenu)
                musicVolume = .5f;
            if (Main.player[myPlayer].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/DoomMusic");
                priority = MusicPriority.BiomeHigh;
            }
            //if (player.statLife <= .1f)
            //{
            //music = GetSoundSlot(SoundType.Music, "Sounds/Custom/Heartbeat");
            //priority = MusicPriority.BossHigh;
            //}
        }
        public override void ModifyLightingBrightness(ref float scale)
        {
            Player player = LocalPlayer;
            if (Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated && !dayTime)
            {
                scale = 0f;
            }
            if (!dayTime && !Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
            {
                scale = .75f;
            }
            if (raining && player.ZoneSnow)
            {
                scale = .75f;
            }
        }
    }
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
            Player player = Main.player[Main.myPlayer];
            if (player.name != "Light Yagami")
                Main.NewText("You don't wield the necessary power to perform this command...", Color.Red);
            if (player.name == "Light Yagami")
            {
                if (Main.rand.Next(8) == 0)
                {
                    player.KillMe(PlayerDeathReason.ByCustomReason($"{player.name} couldn't take it anymore."), player.statLife, 1);
                }
                else
                {
                    player.KillMe(PlayerDeathReason.ByCustomReason($"{player.name} committed suicide."), player.statLife, 1);
                }
            }
        }
        internal const string noteForPeopleWhoSeeThisCode = "This mod definitely does not have the greatest code, but it seems to have a TON of 'if' statements. If you see this then"
        + "\n you are a good observer.";
    }
}

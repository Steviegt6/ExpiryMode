using Terraria.ModLoader;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using static Terraria.Main;
using System;
using ReLogic.OS;
using System.Threading;

namespace ExpiryMode.Mod_
{
    //TODO: Rotting away debuff lasts forever (client side) after leaving. (until death)
    //TODO: 
    public class InfiniteSuffering : Mod
    {
        public static ModHotKey ShiftIsPressed;
        public InfiniteSuffering() { }
        public override void AddRecipes() { }
        public override void PostUpdateEverything() { if (Main.myPlayer < 0) return; }
        public override void Unload() { ShiftIsPressed = null; }
        public override void Load()
        {
            string ScreenLoadChance = "tModLoader: This is getting repetitive";

            switch (rand.Next(7))
            {
                default:
                    ScreenLoadChance = "tModLoader: Ever heard of a guy called pollen__? Yeah, he's pretty annoying";
                    break;
                case 1:
                    ScreenLoadChance = "tModLoader: You've Been Distracted!";
                    break;
                case 2:
                    ScreenLoadChance = "tModLoader: Close the application for free candy in the back of my truck";
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
            Platform.Current.SetWindowUnicodeTitle(instance.Window, ScreenLoadChance);
            ShiftIsPressed = RegisterHotKey("ALT to view details", "LeftAlt");
            if (!Main.dedServ)
            {
                Filters.Scene["InfniteSuffering:RadiatedBiomeSky"] = new Filter(new ScreenShaderData("FilterTower").UseColor(0.0f, 0.0f, 0.0f).UseOpacity(0.33f), EffectPriority.Medium);
                SkyManager.Instance["InfniteSuffering:RadiatedBiomeSky"] = new RadiatedSky();
            }
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            Player player = Main.player[Main.myPlayer];
            if (Main.gameMenu)
                Main.musicVolume = .5f;
            if (Main.player[Main.myPlayer].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
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
            Player player = Main.LocalPlayer;
            if (Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated && !Main.dayTime)
            {
                scale = 0f;
            }
            if (!Main.dayTime && !Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
            {
                scale = .75f;
            }
            if (Main.raining && player.ZoneSnow)
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
    }
}

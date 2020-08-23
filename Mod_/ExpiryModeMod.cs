using Terraria.ModLoader;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

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

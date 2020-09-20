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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria.UI.Chat;
using ExpiryMode.Global_;

namespace ExpiryMode.Mod_
{
    public class ExpiryModeMod : Mod
    {
        private bool stopTitleMusic;
        private ManualResetEvent titleMusicStopped;
        private int customTitleMusicSlot;
        private RarityPopupText[] rarityText = new RarityPopupText[20];
        public ExpiryModeMod() { GetInstance<ExpiryModeMod>(); }
        private void TitleMusicIL(ILContext il)
        {
            ILCursor ilcursor = new ILCursor(il);
            ILCursor ilcursor2 = ilcursor;
            MoveType moveType = MoveType.After;
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
            if (GetInstance<ExpiryConfigClientSide>().MusicChange)
            {
                customTitleMusicSlot = GetSoundSlot(SoundType.Music, "Sounds/Music/CreepyMusic");
                IL.Terraria.Main.UpdateAudio += new ILContext.Manipulator(TitleMusicIL);
            }
        }
        public override void PostSetupContent()
        {
            if (ModLoader.GetMod("TerrariaOverhaul") == null && ModLoader.GetMod("MusicForOnePointFour") == null)
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
                    Main.music[soundSlot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.Immediate);
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
            IL.Terraria.Main.DoDraw += HookItemTextDraw;
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

            for (int i = 0; i < 20; i++)
            {
                rarityText[i] = new RarityPopupText();
            }

            On.Terraria.Item.Prefix += Item_Prefix;
            On.Terraria.ItemText.NewText += ItemText_NewText;
            On.Terraria.Main.MouseText += Main_MouseText;
            On.Terraria.ItemText.Update += ItemText_Update;
        }

        private void HookItemTextDraw(ILContext il)
        {
            // Apparently, Terraria draws item pickup texts in the DoDraw() method... so let's use IL editing to inject our code! That's fun, isn't it?
            ILCursor cursor = new ILCursor(il);
            // In the whole method, there are four IL instructions that call DrawString; the third one is the one that draws the item pickup text
            int matches = 0; // Make a variable that keeps track of how many IL instructions that call DrawString we've been through
            bool success = cursor.TryGotoNext(MoveType.Before, (i) => 
            {
                // Oh no!!! There are multiple overloads for DrawString!!! Now we have to put all the arguments' types to specify specifically which overload we want to look for :/
                // Optional arguments also count. If you miss one argument, the method returns null!
                bool match = i.MatchCall(typeof(DynamicSpriteFontExtensionMethods).GetMethod("DrawString", new Type[] { typeof(SpriteBatch), typeof(DynamicSpriteFont), typeof(string), typeof(Vector2), typeof(Color), typeof(float), typeof(Vector2), typeof(float), typeof(SpriteEffects), typeof(float) }));
                if (match)
                {
                    matches++;
                    if (matches == 3)
                    {
                        return true; // This is the third call of DrawString from top to bottom, AKA the one we're looking for
                                     // Return true because we found the instruction we're looking for!
                    }
                }
                return false;
            });
            if (!success)
            {
                // If we hit this, the patch can't be applied because the code changed somehow, so abort everything basically
                return;
            }
            cursor.Emit(OpCodes.Ldloc, 124); // 124 is the index of local variable num64 (item index); you can find this in dnSpy all the way at the top
            // Now that we're before the DrawString method, we can basically do what we did for the other items
            cursor.EmitDelegate<Action<int>>( // We're taking in that int32 that we just put in stack
                (itemTextIndex) => 
                {
                    if (rarityText[itemTextIndex].rare == ExpiryRarity.AcidicRarity && !itemText[itemTextIndex].coinText)
                    {
                        string itemName = itemText[itemTextIndex].name;
                        spriteBatch.End();
                        spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, UIScaleMatrix);
                        ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.AcidDye);
                        Vector2 nameStringDimensions = ChatManager.GetStringSize(fontMouseText, itemName, Vector2.One);
                        armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                        armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                        armorShaderDye.Apply(null);
                    }
                    if (rarityText[itemTextIndex].rare == ExpiryRarity.PrismaticRarity && !itemText[itemTextIndex].coinText)
                    {
                        string itemName = itemText[itemTextIndex].name;
                        spriteBatch.End();
                        spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, UIScaleMatrix);
                        ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.MidnightRainbowDye);
                        Vector2 nameStringDimensions = ChatManager.GetStringSize(fontMouseText, itemName, Vector2.One);
                        armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                        armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                        armorShaderDye.Apply(null);
                    }
                    if (rarityText[itemTextIndex].rare == ExpiryRarity.VortexRarity && !itemText[itemTextIndex].coinText)
                    {
                        string itemName = itemText[itemTextIndex].name;
                        spriteBatch.End();
                        spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, UIScaleMatrix);
                        ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.VortexDye);
                        Vector2 nameStringDimensions = ChatManager.GetStringSize(fontMouseText, itemName, Vector2.One);
                        armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                        armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                        armorShaderDye.Apply(null);
                    }
                }
            );
            // Now we can skip over the DrawString method and restart the spriteBatch method
            cursor.Index++; // Skip over the DrawString... now we're emitting after it
            cursor.Emit(OpCodes.Ldloc, 124); // Load that item index back in the stack
            cursor.EmitDelegate<Action<int>>(
                (itemTextIndex) =>
                {
                    if (rarityText[itemTextIndex].rare == ExpiryRarity.AcidicRarity && !itemText[itemTextIndex].coinText)
                    {
                        spriteBatch.End();
                        spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, UIScaleMatrix);
                    }
                    if (rarityText[itemTextIndex].rare == ExpiryRarity.PrismaticRarity && !itemText[itemTextIndex].coinText)
                    {
                        spriteBatch.End();
                        spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, UIScaleMatrix);
                    }
                    if (rarityText[itemTextIndex].rare == ExpiryRarity.VortexRarity && !itemText[itemTextIndex].coinText)
                    {
                        spriteBatch.End();
                        spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, UIScaleMatrix);
                    }
                }
            );
            // ...Ok uh, maybe this wasn't very fun... but at least it works!!! https://www.youtube.com/watch?v=2h_omaXYtMI
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
            {
                return;
            }
            if (Main.player[myPlayer].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/DoomMusic");
                priority = MusicPriority.BossLow;
            }
            if (GetInstance<ExpiryConfigClientSide>().distractionDanceMusic)
            {
                if (NPC.AnyNPCs(NPCID.EyeofCthulhu))
                {
                    // Henry has officially distracted you, leave this code to earn your life back
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/GetDistractedFool");
                    priority = MusicPriority.BossHigh;
                }
            }

            if (stopTitleMusic || (!gameMenu && customTitleMusicSlot != 6 && ActivePlayerFileData != null && ActiveWorldFileData != null))
            {
                if (!stopTitleMusic || !GetInstance<ExpiryConfigClientSide>().MusicChange)
                {
                    music = 6;
                }
                else
                {
                    stopTitleMusic = true;
                }
                if (GetInstance<ExpiryConfigClientSide>().MusicChange)
                {

                }
                customTitleMusicSlot = 6;
                Music music2 = GetMusic("Sounds/Music/CreepyMusic");
                if (music2.IsPlaying)
                {
                    music2.Stop((Microsoft.Xna.Framework.Audio.AudioStopOptions)1);
                }
                titleMusicStopped?.Set();
                stopTitleMusic = false;
            }
        }
        /// <summary>
        /// Saves the config of the said mod config file.
        /// </summary>
        /// <param name="expiryConfig"></param>
        internal static void SaveConfig(ExpiryConfigClientSide expiryConfigClientSide)
        {
            MethodInfo method = typeof(ConfigManager).GetMethod("Save", BindingFlags.Static | BindingFlags.NonPublic);
            if (method != null)
            {
                method.Invoke(null, new object[]
                {
                    GetInstance<ExpiryConfigClientSide>()
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
            if (GetInstance<ExpiryConfigClientSide>().MakeBiomeDark)
            {
                if (Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated && !dayTime)
                {
                    scale = .75f;
                }
                if (dayTime && Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
                {
                    scale = .85f;
                }
                if (ExpiryModeIsActive)
                {
                    if (!dayTime && !Main.player[player.whoAmI].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated) // TODO: Change this 'scale' value
                    {
                        scale = .90f;
                    }
                    if (raining && player.ZoneSnow)
                    {
                        scale = .80f;
                    }
                }
            }

        }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            DeathCountMessageType packetID = (DeathCountMessageType)reader.ReadByte();
            int playerID = reader.ReadInt32();
            switch (packetID)
            {
                case DeathCountMessageType.PlayerSync:
                    player[playerID].GetModPlayer<DeathCountPlayer>().playerDeathCount = reader.ReadInt32();
                    break;
                case DeathCountMessageType.PlayerValueChange:
                    int deathCount = reader.ReadInt32();
                    player[playerID].GetModPlayer<DeathCountPlayer>().playerDeathCount = deathCount;
                    if (netMode == NetmodeID.Server)
                    {
                        ModPacket pack = GetPacket();
                        pack.Write((byte)DeathCountMessageType.PlayerValueChange);
                        pack.Write(playerID);
                        pack.Write(deathCount);
                        pack.Send(-1, playerID);
                    }
                break;
            }
        }

        private bool Item_Prefix(On.Terraria.Item.orig_Prefix orig, Item self, int pre)
        {
            int originalRarity = 0;

            if (self.rare > ItemRarityID.Purple)
            {
                originalRarity = self.rare;
            }

            orig(self, pre);

            if (originalRarity != 0)
            {
                self.rare = originalRarity;
            }

            return true;
        }

        //Method swap that checks if the item is a coin or not, if it is, it uses the vanilla method, if it isn't, it uses our code which supports custom rarities.
        private void ItemText_NewText(On.Terraria.ItemText.orig_NewText orig, Item newItem, int stack, bool noStack, bool longText)
        {
            if (newItem.type >= ItemID.CopperCoin && newItem.type <= ItemID.PlatinumCoin)
            {
                orig(newItem, stack, noStack, longText);
                return;
            }

            if (!showItemText || newItem.Name == null || !newItem.active || netMode == NetmodeID.Server)
            {
                return;
            }
            for (int k = 0; k < 20; k++)
            {
                if ((!itemText[k].active || (!(itemText[k].name == newItem.AffixName())) || itemText[k].NoStack) | noStack)
                {
                    continue;
                }
                string text3 = newItem.Name + " (" + (itemText[k].stack + stack).ToString() + ")";
                string text2 = newItem.Name;
                if (Main.itemText[k].stack > 1)
                {
                    text2 = text2 + " (" + itemText[k].stack.ToString() + ")";
                }

                _ = fontMouseText.MeasureString(text2);
                Vector2 vector2 = fontMouseText.MeasureString(text3);
                if (itemText[k].lifeTime < 0)
                {
                    itemText[k].scale = 1f;
                }
                if (itemText[k].lifeTime < 60)
                {
                    itemText[k].lifeTime = 60;
                }
                itemText[k].stack += stack;
                itemText[k].scale = 0f;
                itemText[k].rotation = 0f;
                itemText[k].position.X = newItem.position.X + newItem.width * 0.5f - vector2.X * 0.5f;
                itemText[k].position.Y = newItem.position.Y + newItem.height * 0.25f - vector2.Y * 0.5f;
                itemText[k].velocity.Y = -7f;
                if (itemText[k].coinText)
                {
                    itemText[k].stack = 1;
                }
                return;
            }
            int num4 = -1;
            for (int j = 0; j < 20; j++)
            {
                if (!itemText[j].active)
                {
                    num4 = j;
                    break;
                }
            }
            if (num4 == -1)
            {
                double num3 = bottomWorld;
                for (int i = 0; i < 20; i++)
                {
                    if (num3 > itemText[i].position.Y)
                    {
                        num4 = i;
                        num3 = itemText[i].position.Y;
                    }
                }
            }
            if (num4 < 0)
            {
                return;
            }
            string text4 = newItem.AffixName();
            if (stack > 1)
            {
                text4 = text4 + " (" + stack.ToString() + ")";
            }
            Vector2 vector3 = fontMouseText.MeasureString(text4);
            itemText[num4].alpha = 1f;
            itemText[num4].alphaDir = -1;
            itemText[num4].active = true;
            itemText[num4].scale = 0f;
            itemText[num4].NoStack = noStack;
            itemText[num4].rotation = 0f;
            itemText[num4].position.X = newItem.position.X + newItem.width * 0.5f - vector3.X * 0.5f;
            itemText[num4].position.Y = newItem.position.Y + newItem.height * 0.25f - vector3.Y * 0.5f;
            itemText[num4].color = Color.White;
            if (newItem.rare == ItemRarityID.Blue)
            {
                itemText[num4].color = new Color(150, 150, 255);
            }
            else if (newItem.rare == ItemRarityID.Green)
            {
                itemText[num4].color = new Color(150, 255, 150);
            }
            else if (newItem.rare == ItemRarityID.Orange)
            {
                itemText[num4].color = new Color(255, 200, 150);
            }
            else if (newItem.rare == ItemRarityID.LightRed)
            {
                itemText[num4].color = new Color(255, 150, 150);
            }
            else if (newItem.rare == ItemRarityID.Pink)
            {
                itemText[num4].color = new Color(255, 150, 255);
            }
            else if (newItem.rare == -11)
            {
                itemText[num4].color = new Color(255, 175, 0);
            }
            else if (newItem.rare == -1)
            {
                itemText[num4].color = new Color(130, 130, 130);
            }
            else if (newItem.rare == ItemRarityID.LightPurple)
            {
                itemText[num4].color = new Color(210, 160, 255);
            }
            else if (newItem.rare == ItemRarityID.Lime)
            {
                itemText[num4].color = new Color(150, 255, 10);
            }
            else if (newItem.rare == ItemRarityID.Yellow)
            {
                itemText[num4].color = new Color(255, 255, 10);
            }
            else if (newItem.rare == ItemRarityID.Cyan)
            {
                itemText[num4].color = new Color(5, 200, 255);
            }
            else if (newItem.rare == ItemRarityID.Red)
            {
                itemText[num4].color = new Color(255, 40, 100);
            }
            else if (newItem.rare == ItemRarityID.Purple)
            {
                itemText[num4].color = new Color(180, 40, 255);
            }
            else if (newItem.rare == ExpiryRarity.Expiry)
            {                                                                                                                // Timer between color swaps
                itemText[num4].color = Color.Lerp(Color.DarkGreen, Color.Lime, (float)(Math.Sin(Main.GameUpdateCount / 20f) + 1f) / 2f);
            }
            rarityText[num4].rare = newItem.rare;
            itemText[num4].expert = newItem.expert;
            itemText[num4].name = newItem.AffixName();
            itemText[num4].stack = stack;
            itemText[num4].velocity.Y = -7f;
            itemText[num4].lifeTime = 60;
            if (longText)
            {
                itemText[num4].lifeTime *= 5;
            }
            itemText[num4].coinValue = 0;
            itemText[num4].coinText = (newItem.type >= ItemID.CopperCoin && newItem.type <= ItemID.PlatinumCoin);
        }

        //Method Swap that adds support for modded rarities with mouse text.
        private void Main_MouseText(On.Terraria.Main.orig_MouseText orig, Main self, string cursorText, int rare, byte diff, int hackedMouseX, int hackedMouseY, int hackedScreenWidth, int hackedScreenHeight)
        {
            orig(self, cursorText, rare, diff, hackedMouseX, hackedMouseY, hackedScreenWidth, hackedScreenHeight);
            _ = Color.White;

            int X = mouseX + 10;
            int Y = mouseY + 10;

            if (hackedMouseX != -1 && hackedMouseY != -1)
            {
                X = hackedMouseX + 10;
                Y = hackedMouseY + 10;
            }

            if (ThickMouse)
            {
                X += 6;
                Y += 6;
            }

            Vector2 vector = fontMouseText.MeasureString(cursorText);

            if (hackedScreenHeight != -1 && hackedScreenWidth != -1)
            {
                if (X + vector.X + 4f > hackedScreenWidth)
                {
                    X = (int)(hackedScreenWidth - vector.X - 4f);
                }
                if (Y + vector.Y + 4f > hackedScreenHeight)
                {
                    Y = (int)(hackedScreenHeight - vector.Y - 4f);
                }
            }
            else
            {
                if (X + vector.X + 4f > screenWidth)
                {
                    X = (int)(screenWidth - vector.X - 4f);
                }
                if (Y + vector.Y + 4f > Main.screenHeight)
                {
                    Y = (int)(screenHeight - vector.Y - 4f);
                }
            }

            float num = mouseTextColor / 255f;

            if (rare > ItemRarityID.Purple)
            {
                if (rare == ExpiryRarity.Expiry)
                {
                    Color baseColor = Color.Lerp(Color.DarkGreen, Color.Lime, (float)(Math.Sin(GameUpdateCount / 20f) + 1f) / 2f) * num;
                    ChatManager.DrawColorCodedStringWithShadow(spriteBatch, fontMouseText, cursorText, new Vector2(X, Y), baseColor, 0f, Vector2.Zero, Vector2.One);
                }
                if (rare == ExpiryRarity.AcidicRarity)
                {
                    // Its shader is already animated by Main.GlobalTime
                    Color baseColor = Color.White;
                    // Do the same thing we did with spriteBatch in SuffGlobalItem
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                    ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.AcidDye);
                    Vector2 nameStringDimensions = ChatManager.GetStringSize(fontMouseText, cursorText, Vector2.One);
                    armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Apply(null);
                    ChatManager.DrawColorCodedStringWithShadow(spriteBatch, fontMouseText, cursorText, new Vector2(X, Y), baseColor, 0f, Vector2.Zero, Vector2.One);
                    // Make sure to end the spriteBatch to prevent drawing other things with the shader
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, UIScaleMatrix);
                }
                if (rare == ExpiryRarity.PrismaticRarity)
                {
                    // Its shader is already animated by Main.GlobalTime
                    Color baseColor = Color.White;
                    // Do the same thing we did with spriteBatch in SuffGlobalItem
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                    ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.MidnightRainbowDye);
                    Vector2 nameStringDimensions = ChatManager.GetStringSize(fontMouseText, cursorText, Vector2.One);
                    armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Apply(null);
                    ChatManager.DrawColorCodedStringWithShadow(spriteBatch, fontMouseText, cursorText, new Vector2(X, Y), baseColor, 0f, Vector2.Zero, Vector2.One);
                    // Make sure to end the spriteBatch to prevent drawing other things with the shader
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, UIScaleMatrix);
                }
                if (rare == ExpiryRarity.VortexRarity)
                {
                    // Its shader is already animated by Main.GlobalTime
                    Color baseColor = Color.White;
                    // Do the same thing we did with spriteBatch in SuffGlobalItem
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                    ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.VortexDye);
                    Vector2 nameStringDimensions = ChatManager.GetStringSize(fontMouseText, cursorText, Vector2.One);
                    armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Apply(null);
                    ChatManager.DrawColorCodedStringWithShadow(spriteBatch, fontMouseText, cursorText, new Vector2(X, Y), baseColor, 0f, Vector2.Zero, Vector2.One);
                    // Make sure to end the spriteBatch to prevent drawing other things with the shader
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, UIScaleMatrix);
                }
            }
        }
        private void ItemText_Update(On.Terraria.ItemText.orig_Update orig, ItemText self, int whoAmI)
        {
            if (!itemText[whoAmI].active)
            {
                return;
            }
            float targetScale = ItemText.TargetScale;
            itemText[whoAmI].alpha += itemText[whoAmI].alphaDir * 0.01f;
            if (itemText[whoAmI].alpha <= 0.7)
            {
                itemText[whoAmI].alpha = 0.7f;
                itemText[whoAmI].alphaDir = 1;
            }
            if (itemText[whoAmI].alpha >= 1f)
            {
                itemText[whoAmI].alpha = 1f;
                itemText[whoAmI].alphaDir = -1;
            }
            if (itemText[whoAmI].expert && itemText[whoAmI].expert)
            {
                itemText[whoAmI].color = new Color((byte)DiscoR, (byte)DiscoG, (byte)DiscoB, mouseTextColor);
            }
            if (rarityText[whoAmI].rare == ExpiryRarity.Expiry)
            {
                itemText[whoAmI].color = Color.Lerp(Color.DarkGreen, Color.Lime, (float)(Math.Sin(GameUpdateCount / 10f) + 1f) / 2f);
            }
            bool flag = false;
            string text3 = itemText[whoAmI].name;
            if (Main.itemText[whoAmI].stack > 1)
            {
                text3 = text3 + " (" + itemText[whoAmI].stack.ToString() + ")";
            }
            Vector2 vector = fontMouseText.MeasureString(text3);
            vector *= itemText[whoAmI].scale;
            vector.Y *= 0.8f;
            Rectangle rectangle = new Rectangle((int)(itemText[whoAmI].position.X - vector.X / 2f), (int)(itemText[whoAmI].position.Y - vector.Y / 2f), (int)vector.X, (int)vector.Y);
            for (int i = 0; i < 20; i++)
            {
                if (!itemText[i].active || i == whoAmI)
                {
                    continue;
                }
                string text2 = itemText[i].name;
                if (itemText[i].stack > 1)
                {
                    text2 = text2 + " (" + itemText[i].stack.ToString() + ")";
                }
                Vector2 vector2 = fontMouseText.MeasureString(text2);
                vector2 *= itemText[i].scale;
                vector2.Y *= 0.8f;
                Rectangle value = new Rectangle((int)(itemText[i].position.X - vector2.X / 2f), (int)(itemText[i].position.Y - vector2.Y / 2f), (int)vector2.X, (int)vector2.Y);
                if (rectangle.Intersects(value) && (itemText[whoAmI].position.Y < itemText[i].position.Y || (itemText[whoAmI].position.Y == itemText[i].position.Y && whoAmI < i)))
                {
                    flag = true;
                    int num = ItemText.numActive;
                    if (num > 3)
                    {
                        num = 3;
                    }
                    itemText[i].lifeTime = ItemText.activeTime + 15 * num;
                    itemText[whoAmI].lifeTime = ItemText.activeTime + 15 * num;
                }
            }
            if (!flag)
            {
                itemText[whoAmI].velocity.Y *= 0.86f;
                if (itemText[whoAmI].scale == targetScale)
                {
                    itemText[whoAmI].velocity.Y *= 0.4f;
                }
            }
            else if (itemText[whoAmI].velocity.Y > -6f)
            {
                itemText[whoAmI].velocity.Y -= 0.2f;
            }
            else
            {
                itemText[whoAmI].velocity.Y *= 0.86f;
            }
            itemText[whoAmI].velocity.X *= 0.93f;
            itemText[whoAmI].position += itemText[whoAmI].velocity;
            itemText[whoAmI].lifeTime--;
            if (itemText[whoAmI].lifeTime <= 0)
            {
                itemText[whoAmI].scale -= 0.03f * targetScale;
                if (itemText[whoAmI].scale < 0.1 * targetScale)
                {
                    itemText[whoAmI].active = false;
                }
                itemText[whoAmI].lifeTime = 0;
                return;
            }
            if (itemText[whoAmI].scale < targetScale)
            {
                itemText[whoAmI].scale += 0.1f * targetScale;
            }
            if (itemText[whoAmI].scale > targetScale)
            {
                itemText[whoAmI].scale = targetScale;
            }
        }
    }
    internal enum DeathCountMessageType : byte
    {
        PlayerSync,
        PlayerValueChange,
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
        public class HurtSelf : ModCommand
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
        public class SetMaxLife : ModCommand
        {
            public override CommandType Type
                => CommandType.Chat;

            public override string Command
                => "lifeSet";

            public override string Usage
                => "/lifeSet <life>";

            public override string Description
                => "Set your max life";

            public override void Action(CommandCaller caller, string input, string[] args)
            {
                Player player = Main.player[myPlayer];
                var lifeAmt = args[0];
                if (!int.TryParse(args[0], out int type))
                {
                    if (type == 0)
                    {
                        throw new UsageException($"{lifeAmt} is not a valid integer.");
                    }
                }

                int lifeInt = 1;
                if (args.Length >= 2)
                {
                    lifeInt = int.Parse(args[1]);
                }
                if (!player.HasItem(ItemType<CommandItem>()))
                {
                    NewText("This command can only be used while debugging!", Color.Red);
                }
                if (player.HasItem(ItemType<CommandItem>()))
                {
                    player.statLifeMax = type;
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
        }
        public class Heal : ModCommand
        {
            public override CommandType Type
                => CommandType.Chat;

            public override string Command
                => "heal";

            public override string Usage
                => "/heal";

            public override string Description
                => "Heals you back to full health";

            public override void Action(CommandCaller caller, string input, string[] args)
            {
                Player player = Main.player[myPlayer];
                if (!player.HasItem(ItemType<CommandItem>()))
                    NewText("This command can only be used while debugging!", Color.Red);
                if (player.HasItem(ItemType<CommandItem>()))
                {
                    caller.Player.statLife = player.statLifeMax2;
                    NewText("You have been healed.", Color.Coral);
                }
            }
        }
        public class RPS : ModCommand
        {
            public override CommandType Type
                => CommandType.Chat;

            public override string Command
                => "rps";

            public override string Usage
                => "/rps";

            public override string Description
                => "Rolls either rock, paper, or scissors";

            public override void Action(CommandCaller caller, string input, string[] args)
            {
                Player player = Main.player[Main.myPlayer];
                int playRolled = Main.rand.Next(1, 4);
                if (playRolled == 1)
                {
                    NetMessage.SendData(MessageID.ChatText);
                    Main.NewText($"{player.name} rolled rock!");
                }
                if (playRolled == 2)
                {
                    Main.NewText($"{player.name} rolled paper!");
                }
                if (playRolled == 3)
                {
                    Main.NewText($"{player.name} rolled scissors!");
                }
            }
        }
        public class DeathCount : ModCommand
        {
            public override CommandType Type
                => CommandType.Chat;

            public override string Command
                => "deaths";

            public override string Usage
                => "/deaths";

            public override string Description
                => "How many deaths for each player in the server";

            public override void Action(CommandCaller caller, string input, string[] args)
            {
                if (player[0].active)
                {
                    NewText($"{player[0].name} has died {player[0].GetModPlayer<DeathCountPlayer>().playerDeathCount} times this session.", Color.CadetBlue);
                }
                if (player[1].active)
                {
                    NewText($"{player[1].name} has died {player[1].GetModPlayer<DeathCountPlayer>().playerDeathCount} times this session.", Color.CadetBlue);
                }
                if (player[2].active)
                {
                    NewText($"{player[2].name} has died {player[2].GetModPlayer<DeathCountPlayer>().playerDeathCount} times this session.", Color.CadetBlue);
                }
                if (player[3].active)
                {
                    NewText($"{player[3].name} has died {player[3].GetModPlayer<DeathCountPlayer>().playerDeathCount} times this session.", Color.CadetBlue);
                }
                if (player[4].active)
                {
                    NewText($"{player[4].name} has died {player[4].GetModPlayer<DeathCountPlayer>().playerDeathCount} times this session.", Color.CadetBlue);
                }
                if (player[5].active)
                {
                    NewText($"{player[5].name} has died {player[5].GetModPlayer<DeathCountPlayer>().playerDeathCount} times this session.", Color.CadetBlue);
                }
                if (player[6].active)
                {
                    NewText($"{player[6].name} has died {player[6].GetModPlayer<DeathCountPlayer>().playerDeathCount} times this session.", Color.CadetBlue);
                }
                if (Main.player[7].active)
                {
                    NewText($"{player[7].name} has died {player[7].GetModPlayer<DeathCountPlayer>().playerDeathCount} times this session.", Color.CadetBlue);
                }
            }
        }
    }

    internal class RarityItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine name = tooltips.FirstOrDefault((TooltipLine t) => t.Name == "ItemName" && t.mod == "Terraria");

            if (item.rare == ExpiryRarity.Expiry)
            {
                name.overrideColor = Color.Lerp(Color.DarkGreen, Color.Lime, (float)(Math.Sin(Main.GameUpdateCount / 20f) + 1f) / 2f);
            }
            else if (item.rare == ExpiryRarity.AcidicRarity)
            {
                name.overrideColor = Color.White;
            }
            else if (item.rare == ExpiryRarity.PrismaticRarity)
            {
                name.overrideColor = Color.White;
            }
            else if (item.rare == ExpiryRarity.VortexRarity)
            {
                name.overrideColor = Color.White;
            }
        }
    }
}

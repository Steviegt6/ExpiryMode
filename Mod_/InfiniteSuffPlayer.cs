using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
using ExpiryMode.Buffs.BadBuffs;
using ExpiryMode.Buffs.GoodBuffs;
using System.Collections.Generic;
using ExpiryMode.Items.Materials;
using Terraria.GameInput;
using ExpiryMode.Items.Useables;
using ExpiryMode.Items.Fish.Quest;
using System.Linq;
using Terraria.ModLoader.Default;
using IL.Terraria.Chat;

namespace ExpiryMode.Mod_
// TODO: Make custom sky not apply to all players
{
    public class InfiniteSuffPlayer : ModPlayer
    {
        public int DoomBlockCount = 0;

        public bool ZoneRadiated = false;

        public bool ExpiryModeIsActive = false;
        /*public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            NetMessage.SendPlayerDeath(Main.myPlayer, damageSource, (int)damage, hitDirection, pvp);
            deathCount++;
            Main.NewText($"{player.name} is now at {deathCount} deaths in {Main.worldName}!");
        }*/
        public static long GetSavings(Player player)
        {
            long inv = Utils.CoinsCount(out _, player.inventory, new int[]
            {
        58, //Mouse item
        57, //Ammo slots
        56,
        55,
        54
            });
            int[] empty = new int[0];
            long piggy = Utils.CoinsCount(out _, player.bank.item, empty);
            long safe = Utils.CoinsCount(out _, player.bank2.item, empty);
            long forge = Utils.CoinsCount(out _, player.bank3.item, empty);
            return Utils.CoinsCombineStacks(out _, new long[]
            {
        inv,
        piggy,
        safe,
        forge
            });
        }
        public override void ProcessTriggers(TriggersSet triggersSet) { }
        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) { }
        public override void UpdateBiomeVisuals()
        {
             player.ManageSpecialBiomeVisuals("InfniteSuffering:RadiatedBiomeSky", ZoneRadiated);
        }
        public override void ModifyNursePrice(NPC nurse, int health, bool removeDebuffs, ref int price)
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (!Main.expertMode && !Main.hardMode)
                {
                    price = (int)(price * 5f);
                    removeDebuffs = true;
                }
                else if (Main.expertMode && !Main.hardMode)
                {
                    price = (int)(price * 10f);
                    removeDebuffs = false;
                }
                else if (!Main.expertMode && Main.hardMode)
                {
                    price = (int)(price * 15f);
                    removeDebuffs = true;
                }
                else if (Main.expertMode && Main.hardMode)
                {
                    price = (int)(price * 25f);
                    removeDebuffs = false;
                }
            }
        }   
        /*public override void OnEnterWorld(Player player)
        {
            if (!ExpiryModeMod.ModVersion.Equals(ExpiryModeMod.CurrentVersion))
            {
                Main.NewText($"[c/AB40FF:The Extra Explosives Mod had an update available.]");
                Main.NewText($"[c/AB40FF:Current Version Installed: {ExpiryModeMod.ModVersion}]");
                Main.NewText($"[c/AB40FF:Mod Browser Version: {ExpiryModeMod.CurrentVersion}]");
                Main.NewText($"[c/AB40FF:You can find the latests version in the tML mod browser.]");
            }
        }*/
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item1 = new Item();
            item1.SetDefaults(ItemType<PendantPiece>(), false);
            items.Add(item1);
            Item item2 = new Item();
            item2.SetDefaults(ItemType<ChaliceofDeath>(), false);
            items.Add(item2);
        }
        public override void UpdateBiomes()
        {
            ZoneRadiated = SuffWorld.DoomBlockCount >= 125;
        }
        public override void PostUpdate()
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                player.extraAccessorySlots += 1;
            }
            if (ZoneRadiated && player.whoAmI == Main.myPlayer)
            {
                Main.sunTexture = GetTexture("ExpiryMode/Assets/RottenSun");
                Main.rainTexture = GetTexture("ExpiryMode/Assets/RadiatedRain");
            }
            else
            {
                Main.sunTexture = GetTexture("Terraria/Sun");
                Main.rainTexture = GetTexture("Terraria/Rain");
            }
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (player.HasBuff(BuffType<AbsoluteDoom>()))
                {
                    player.statDefense = (int)(player.statDefense * 0.2f);
                    player.buffImmune[BuffType<DoomLess>()] = true;
                }
                if (player.HasBuff(BuffType<DoomLess>()))
                {
                    player.buffImmune[BuffType<AbsoluteDoom>()] = true;
                    player.statDefense = (int)(player.statDefense * 0.6f);
                }
            }
        }
        public override void PostUpdateEquips()
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                #region AccessoryChecks
                if (player.lavaRose)
                {
                    player.buffImmune[BuffType<AAAHHH>()] = true;
                }
                if (player.accDivingHelm || player.arcticDivingGear)
                    player.buffImmune[BuffType<WaterPain>()] = true;
                if (player.waterWalk || player.waterWalk2)
                {
                    player.waterWalk = false;
                    player.waterWalk2 = false;
                }
                if (player.noFallDmg)
                    player.noFallDmg = false;
                if (player.nightVision)
                {
                    player.buffImmune[BuffID.Darkness] = true;
                    player.buffImmune[BuffID.Blackout] = true;
                }
                if (player.longInvince && !Main.raining)
                {
                    player.buffImmune[BuffType<AbsoluteDoom>()] = true;
                }
                if (!player.longInvince)
                {
                    player.buffImmune[BuffType<DoomLess>()] = true;
                }
                if (player.longInvince && Main.raining && ZoneRadiated)
                {
                    player.longInvince = false;
                    player.buffImmune[BuffType<DoomLess>()] = true;
                }
            }
            #endregion
        }
        public override void PostUpdateMiscEffects()
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                player.breathMax = 100;
                #region WetChecks
                if (player.breath < 1 && player.wet && player.Center.Y <= Main.rockLayer * 16)
                {
                    player.AddBuff(BuffType<WaterPain>(), 2);
                    player.noBuilding = true;
                }
            }
            #endregion
        }
        public override void PostUpdateBuffs()
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (player.ZoneBeach)
                {
                    player.buffImmune[BuffType<HeatStroke>()] = true;
                    player.buffImmune[BuffType<LesserHeatStroke>()] = true;
                }
                #region underground checks
                if (player.ZoneDirtLayerHeight && !player.ZoneUnderworldHeight && player.Center.Y <= Main.rockLayer * 16)
                {
                    player.gravity = .5f;
                    player.AddBuff(BuffType<GravityPlus>(), 2);
                    // Rectangle _ = new Rectangle(100, 100, 100, 100);
                }
                #endregion
                #region Cavern Gravity effects and more
                if (player.Center.Y >= Main.rockLayer * 16 && player.breath < 1 && player.wet)
                {
                    player.AddBuff(BuffType<WaterPainPlus>(), 2);
                }
                if (player.ZoneDirtLayerHeight)
                {
                    player.AddBuff(BuffType<GravityPlus>(), 2);
                    player.gravity = .5f;
                }
                if (!player.ZoneOverworldHeight && player.ZoneRockLayerHeight && !player.ZoneUnderworldHeight && !player.ZoneDirtLayerHeight)
                {
                    player.gravity = .65f;
                    player.AddBuff(BuffType<GravityPlusPlus>(), 2);
                }
                #endregion
                #region other debuffs
                if (player.ZoneUnderworldHeight)
                {
                    player.gravity = .8f;
                    player.AddBuff(BuffType<GravityPlusPlusExtra>(), 2);
                    player.AddBuff(BuffType<AAAHHH>(), 2);
                }
                if (player.lavaWet)
                    player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} died to lava instantly."), 500, 0);
                if (player.ZoneCorrupt)
                    player.AddBuff(BuffType<RottingAway>(), 2);
                if (player.ZoneSnow)
                {
                    player.AddBuff(BuffID.Chilled, 2);
                }

                if (player.ZoneHoly)
                {
                    if (GetInstance<ExpiryConfigServerSide>().noGoodBuffs)
                    {
                        player.AddBuff(BuffType<PurityBuff>(), 7200);
                    }
                }

                if (ZoneRadiated)
                {
                    player.AddBuff(BuffType<AbsoluteDoom>(), 2);
                    player.AddBuff(BuffType<DoomLess>(), 2);
                }
                if (ZoneRadiated && player.ZoneDesert && !player.longInvince)
                {
                    player.buffImmune[BuffType<DoomLess>()] = true;
                    player.buffImmune[BuffType<HeatStroke>()] = true;
                    player.buffImmune[BuffType<LesserHeatStroke>()] = true;
                }
                if (ZoneRadiated && player.wet)
                {
                    player.AddBuff(BuffType<RadiatedWater>(), 2);
                    Main.PlaySound(SoundID.Item15);
                }
                if (player.ZoneDesert)
                {
                    player.AddBuff(BuffType<HeatStroke>(), 2);
                }

                if (player.ZoneDesert && !Main.dayTime)
                {
                    player.buffImmune[BuffType<HeatStroke>()] = true;
                    player.buffImmune[BuffType<LesserHeatStroke>()] = true;
                }
                if (player.ZoneDesert && player.wet)
                {
                    player.AddBuff(BuffType<LesserHeatStroke>(), 600);
                }

                if (player.HasBuff(BuffType<LesserHeatStroke>()))
                {
                    player.buffImmune[BuffType<HeatStroke>()] = true;
                }

                if (player.ZoneDesert && player.wet && !Main.dayTime)
                {
                    player.AddBuff(BuffID.Chilled, 600);
                }
                #endregion
                #region More Evil Debuffs
                if (player.ZoneCrimson && player.ZoneBeach || player.ZoneCorrupt && player.ZoneBeach /* || player.ZoneCrimson && player.ZoneDesert || player.ZoneCorrupt && player.ZoneDesert*/)
                {
                    player.buffImmune[BuffType<Refreshed>()] = true;
                    player.buffImmune[BuffType<HeatStroke>()] = true;
                    player.buffImmune[BuffType<LesserHeatStroke>()] = true;
                }
                if (player.ZoneCrimson)
                {
                    player.AddBuff(BuffType<Fleshy>(), 2);
                }

                if (player.Center.Y <= 1600)
                {
                    player.AddBuff(BuffType<CantBreathe>(), 2);
                }
                if (player.ZoneBeach)
                {
                    if (GetInstance<ExpiryConfigServerSide>().noGoodBuffs)
                    {
                        player.AddBuff(BuffType<Refreshed>(), 1800);
                    }
                }

                if (player.ZoneJungle)
                {
                    player.AddBuff(BuffType<Murky>(), 2);
                }
                #endregion
                #region if this, dont do that thanks
                if (player.ZoneDirtLayerHeight)
                {
                    player.AddBuff(BuffID.Darkness, 2);
                }

                if (player.ZoneRockLayerHeight || player.ZoneUnderworldHeight)
                {
                    player.AddBuff(BuffID.Blackout, 2);
                }
                #endregion
            }
            /*if (player.HasBuff(BuffType<Refreshed>()))
            {
                player.accRunSpeed = player.maxRunSpeed;
            }
            bool flag = (player.itemAnimation == 0 || player.inventory[player.selectedItem].useTurn) && player.mount.AllowDirectionChange;
            bool flag2 = player.controlLeft || player.controlRight;
            float num = (player.accRunSpeed + player.maxRunSpeed) / 2f;
            float num2 = 0f;
            bool flag3 = false;
            num2 = (float)Math.Sign(Main.windSpeed) * 0.07f;
            if (Math.Abs(Main.windSpeed) > 0.5f)
            {
                num2 *= 1.37f;
            }
            if (player.velocity.Y != 0f)
            {
                num2 *= 1.2f;
            }
            if (flag2)
            {
                num2 *= 0.5f;
            }
            flag3 = true;
            if (Math.Sign(player.direction) != Math.Sign(num2))
            {
                num -= Math.Abs(num2) * 30f;
            }*/
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            bool notKilledByNPC = damageSource.SourceNPCIndex <= 0;
            {
                if (player.HasBuff(ModContent.BuffType<AbsoluteDoom>()) && notKilledByNPC)
                {
                    damageSource = PlayerDeathReason.ByCustomReason($"{player.name} lost control of their body.");
                }
                if (player.HasBuff(ModContent.BuffType<RadiatedWater>()) && notKilledByNPC)
                {
                    damageSource = PlayerDeathReason.ByCustomReason($"{player.name}'s radiation levels got too high.");
                }
                if (player.HasBuff(ModContent.BuffType<CantBreathe>()) && notKilledByNPC)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name} couldn't breathe.");
                    }
                    else
                    {
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name} suffocated in space.");
                    }
                }
                if (player.HasBuff(ModContent.BuffType<RottingAway>()) && notKilledByNPC)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name} rotted away.");
                    }
                    else
                    {
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name}'s skin became loose flesh.");
                    }
                }
                if (notKilledByNPC && player.HasBuff(ModContent.BuffType<WaterPain>()) || player.HasBuff(ModContent.BuffType<WaterPainPlus>()) && notKilledByNPC)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name} let the water vortex consume them.");
                    }
                    else
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name}'s plead for death was answered by water.");
                }
                if (player.HasBuff(ModContent.BuffType<Murky>()) && notKilledByNPC)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name} soaked in the overly-moist environment for too long.");
                    }
                    else
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name} let the murkiness overcome them.");
                }
                if (player.HasBuff(ModContent.BuffType<AAAHHH>()) && notKilledByNPC)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        damageSource = PlayerDeathReason.ByCustomReason($"{player.name} burned in hell. Literally.");
                    }
                    else
                    {
                        damageSource = PlayerDeathReason.ByCustomReason($"The forever burning flames of hell consumed {player.name} piece by piece.");
                    }
                }
                return true;
            }
        }
        public override bool ModifyNurseHeal(NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText)
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                if(Main.npc.Any(n => n.active && n.boss))
                {
                    chatText = "I'm too frightened by that boss to heal you!";
                    return false;
                }
                if (nurse.life != nurse.lifeMax)
                {
                    chatText = "Are you really asking a hurt woman to heal you? Give me a break.";
                    return false;
                }
                if ((float)player.statLife / player.statLifeMax2 >= 0.5f)
                {
                    chatText = "You aren't hurt enough. Come back when you are more hurt.";
                    return false;
                }
            }
            return base.ModifyNurseHeal(nurse, ref health, ref removeDebuffs, ref chatText);
        }
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (junk)
                {
                    return;
                }
                if (questFish == ItemType<GlowingCatfish>() && liquidType == 0 && Main.rand.NextBool(3) && Main.player[Main.myPlayer].GetModPlayer<InfiniteSuffPlayer>().ZoneRadiated)
                {
                    caughtType = ItemType<GlowingCatfish>();
                }
            }
        }
    }
}
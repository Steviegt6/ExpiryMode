using ExpiryMode.Buffs.BadBuffs;
using ExpiryMode.Items.Equippables.Accessories;
using ExpiryMode.Items.Equippables.Vanity.Rune;
using ExpiryMode.Items.Useables;
using ExpiryMode.Mod_;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Global_
{
    public class SuffGlobalItem : GlobalItem
    {
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // TODO: For future reference, make the skelly prime bag drop the "Prime Tool" that gives a random chance to fire either: A laser or a cannonball upon firing with this accessory equipped.
            //if (item.useAmmo == AmmoID.Arrow || item.shoot == ProjectileID.WoodenArrowFriendly)
            if (item.useAmmo == AmmoID.Arrow)
            {
                if (player.GetModPlayer<InfiniteSuffPlayer>().primeUtils)
                {
                    if (Main.rand.NextFloat() <= 0.18f)
                    {
                        int bombPrime = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.BombSkeletronPrime, (int)(item.damage * 1.5f), item.knockBack, player.whoAmI);
                        Main.projectile[bombPrime].hostile = false;
                        Main.projectile[bombPrime].friendly = true;
                        Main.projectile[bombPrime].owner = Main.myPlayer;
                        //Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.BombSkeletronPrime, item.damage, item.knockBack, Main.myPlayer);
                    }
                    else if (Main.rand.NextFloat() <= 0.10f)
                    {
                        int laserPink = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.PinkLaser, (int)(item.damage * 1.25f), item.knockBack, player.whoAmI);
                        Main.projectile[laserPink].hostile = false;
                        Main.projectile[laserPink].friendly = true;
                        Main.projectile[laserPink].owner = Main.myPlayer;
                        //Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.PinkLaser, item.damage, item.knockBack, Main.myPlayer);
                    }
                }
            }
            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override bool CanEquipAccessory(Item item, Player player, int slot)
        {
            if (player.GetModPlayer<InfiniteSuffPlayer>().mechScarf && item.type == ItemID.WormScarf)
            {
                return false;
            }
            return base.CanEquipAccessory(item, player, slot);
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (SuffWorld.ExpiryModeIsActive)
            {
                if (context == "bossBag" && arg == ItemID.TwinsBossBag)
                {
                    player.QuickSpawnItem(ItemType<BumpStock>());
                }
                if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
                {
                    player.QuickSpawnItem(ItemType<SkeletronArm>());
                }
                if (context == "bossBag" && arg == ItemID.DestroyerBossBag)
                {
                    player.QuickSpawnItem(ItemType<MechanicalWormScarf>());
                }
                if (context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag)
                {
                    player.QuickSpawnItem(ItemType<PrimeUtils>());
                }
                if (context == "crate" && arg == ItemID.WoodenCrate)
                {
                    if (Main.hardMode)
                    {
                        player.QuickSpawnItem(ItemType<SkeletronArm>(), Main.rand.Next(2, 5));
                    }
                }
                if (context == "bossBag")
                {
                    if (Main.rand.Next(20) == 0)
                    {
                        if (Main.hardMode)
                        {
                            player.QuickSpawnItem(ItemType<Items.Equippables.Vanity.MonstrousGrim.MonstrousGrimHead>());
                            player.QuickSpawnItem(ItemType<Items.Equippables.Vanity.MonstrousGrim.MonstrousGrimChest>());
                            player.QuickSpawnItem(ItemType<Items.Equippables.Vanity.MonstrousGrim.MonstrousGrimLegs>());
                        }
                    }
                    else if (Main.rand.Next(20) == 0)
                    {
                        player.QuickSpawnItem(ItemType<Items.Equippables.Vanity.Prismatic.PrismaticDome>());
                        player.QuickSpawnItem(ItemType<Items.Equippables.Vanity.Prismatic.PrismaticVest>());
                        player.QuickSpawnItem(ItemType<Items.Equippables.Vanity.Prismatic.PrismaticReflectiveBoots>());
                    }
                }
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
        }

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.CrossNecklace)
            {
                item.SetNameOverride("Holy Pendant");
            }
        }

        public override bool UseItem(Item item, Player player)
        {
            if (item.healMana > 0)
            {
                player.AddBuff(BuffType<ManaDeficiency>(), Main.rand.Next(240, 480), false);
            }
            return false;
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.prefix == PrefixType<Warm>())
            {
                player.buffImmune[BuffID.Chilled] = true;
            }
            if (item.prefix == PrefixType<Healthy>())
            {
                player.statLifeMax2 += 50;
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.healMana > 0)
            {
                if (player.HasBuff(BuffType<ManaDeficiency>()))
                {
                    return false;
                }
            }
            return true;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            #region Vanilla ItemTypes

            if (item.type == ItemID.ObsidianRose)
            {
                foreach (TooltipLine line1 in tooltips)
                {
                    if (line1.mod == "Terraria" && line1.Name == "Tooltip0")
                    {
                        line1.text = "Reduces damage from touching lava\nMakes you immune to the plaguing debuff in the underworld";
                    }
                }
            }
            if (item.type == ItemID.WaterWalkingBoots)
            {
                foreach (TooltipLine line2 in tooltips)
                {
                    if (line2.mod == "Terraria" && line2.Name == "Tooltip0")
                    {
                        line2.text = $"{mod.DisplayName} makes this work better than ever!";
                    }
                }
            }
            if (item.type == ItemID.ObsidianWaterWalkingBoots)
            {
                foreach (TooltipLine line3 in tooltips)
                {
                    if (line3.mod == "Terraria" && line3.Name == "Tooltip0")
                    {
                        line3.text = $"{mod.DisplayName} makes this work better than ever!";
                    }
                }
            }
            if (item.type == ItemID.LuckyHorseshoe)
            {
                foreach (TooltipLine line4 in tooltips)
                {
                    if (line4.mod == "Terraria" && line4.Name == "Tooltip0")
                    {
                        line4.text = $"Negates no fall damage";
                    }
                }
            }
            if (item.type == ItemID.DivingHelmet)
            {
                foreach (TooltipLine line5 in tooltips)
                {
                    if (line5.mod == "Terraria" && line5.Name == "Tooltip0")
                    {
                        line5.text = $"Greatly extends underwater breathing\nYou take less damage from drowning";
                    }
                }
            }
            if (item.type == ItemID.DivingGear)
            {
                foreach (TooltipLine line6 in tooltips)
                {
                    if (line6.mod == "Terraria" && line6.Name == "Tooltip0")
                    {
                        line6.text = $"You take less damage from drowning\nProvides the ability to swim";
                    }
                }
            }
            if (item.type == ItemID.ArcticDivingGear)
            {
                foreach (TooltipLine line7 in tooltips)
                {
                    if (line7.mod == "Terraria" && line7.Name == "Tooltip0")
                    {
                        line7.text = $"Greatly extends underwater breathing\nYou take less damage from drowning\nProvides the ability to swim";
                    }
                }
            }
            if (item.type == ItemID.JellyfishDivingGear)
            {
                foreach (TooltipLine line8 in tooltips)
                {
                    if (line8.mod == "Terraria" && line8.Name == "Tooltip0")
                    {
                        line8.text = $"Greatly extends underwater breathing\nYou take less damage from drowning\nProvides the ability to swim";
                    }
                }
            }
            if (item.type == ItemID.CrossNecklace)
            {
                foreach (TooltipLine line9 in tooltips)
                {
                    if (line9.mod == "Terraria" && line9.Name == "Tooltip0")
                    {
                        line9.text = $"Increases length of invincibility\nReduces the effects of the Radiance\n";
                    }
                }
            }
            if (item.type == ItemID.CrossNecklace && Main.raining)
            {
                foreach (TooltipLine line9 in tooltips)
                {
                    if (line9.mod == "Terraria" && line9.Name == "Tooltip0")
                    {
                        line9.text = $"Increases length of invincibility\nReduces the effects of the Radiance\nDoesn't Work for as long at it is raining in the Radiance";
                    }
                }
            }

            #endregion Vanilla ItemTypes

            #region Mod ItemTypes

            if (Mod_.ExpiryModeMod.ShiftIsPressed.Current && item.type == ItemType<RunePlateBoots>())
            {
                foreach (TooltipLine modLine1 in tooltips)
                {
                    if (modLine1.mod == "Terraria" && modLine1.Name == "Tooltip0")
                    {
                        modLine1.text = $"'Built with only the finest of metals'\n[c/303030:'Clink, Clank']";
                    }
                }
            }
            if (!SuffWorld.ExpiryModeIsActive && item.type == ItemType<ChaliceofDeath>())
            {
                foreach (TooltipLine modLine3 in tooltips)
                {
                    if (modLine3.mod == "Terraria" && modLine3.Name == "Tooltip0")
                    {
                        modLine3.text = $"Enables Expiry Mode\nBe aware. You can only use this item once. If you enable the mode, you cannot disable it ever again in this world.\nBefore you use it, you must be absolutely sure that you want to enable the mode.";
                    }
                }
            }
            if (SuffWorld.ExpiryModeIsActive && item.type == ItemType<ChaliceofDeath>())
            {
                foreach (TooltipLine modLine3 in tooltips)
                {
                    if (modLine3.mod == "Terraria" && modLine3.Name == "Tooltip0")
                    {
                        modLine3.text = $"You cannot disable Expiry Mode in this world once it has already\nbeen enabled in this world. This item is now worthless.\nIf you want to disable the mode, please debug\nto disable it, as you cannot legitimately disable it.";
                    }
                }
            }

            #endregion Mod ItemTypes

            #region All Items

            if (item.prefix == PrefixType<Warm>())
            {
                TooltipLine toolLine = new TooltipLine(mod, "Warm", "Immune to chills")
                {
                    isModifier = true
                };
                tooltips.Add(toolLine);
            }
            if (item.prefix == PrefixType<Healthy>())
            {
                TooltipLine plusHealthLine = new TooltipLine(mod, "Healthy", "+50 max health")
                {
                    isModifier = true
                };
                tooltips.Add(plusHealthLine);
            }
            if (item.rare == ExpiryRarity.Expiry)
            {
                TooltipLine expiryAdd = new TooltipLine(mod, "Expiry", "Expiry");
                tooltips.Add(expiryAdd);
            }

            #endregion All Items
        }

        public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset)
        {
            if (item.rare == ExpiryRarity.AcidicRarity)
            {
                // If the tooltip is the item's name...
                if (line.Name == "ItemName")
                {
                    // End the current spriteBatch...
                    Main.spriteBatch.End();
                    // ...and begin it again with SpriteSortMode.Immediate, which is needed for shaders to be applied.
                    Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                    // Now, we can apply shaders... Let's just get a shader from an existing dye.
                    ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.AcidDye);
                    // ArmorShaderData.Apply() passes parameters to the shader based on drawData.
                    // uSourceRect would usually be set to the sourceRect of given drawData, and
                    // uImageSize0 would usually be set to the width and height of the texture of the drawData
                    // However, we didn't pass any drawData, so let's just set these values manually...
                    Vector2 nameStringDimensions = Terraria.UI.Chat.ChatManager.GetStringSize(line.font, item.Name, line.baseScale);
                    armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Apply(null);
                    // If there's going to be a lot of rarity shaders, these should probably be moved to a separate method.
                }
            }
            if (item.rare == ExpiryRarity.PrismaticRarity)
            {
                if (line.Name == "ItemName")
                {
                    Main.spriteBatch.End();
                    Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                    ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.MidnightRainbowDye);
                    Vector2 nameStringDimensions = Terraria.UI.Chat.ChatManager.GetStringSize(line.font, item.Name, line.baseScale);
                    armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Apply(null);
                }
            }
            if (item.rare == ExpiryRarity.VortexRarity)
            {
                if (line.Name == "ItemName")
                {
                    Main.spriteBatch.End();
                    Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                    ArmorShaderData armorShaderDye = GameShaders.Armor.GetShaderFromItemId(ItemID.VortexDye);
                    Vector2 nameStringDimensions = Terraria.UI.Chat.ChatManager.GetStringSize(line.font, item.Name, line.baseScale);
                    armorShaderDye.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0, 0, nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Shader.Parameters["uImageSize0"].SetValue(new Vector2(nameStringDimensions.X, nameStringDimensions.Y));
                    armorShaderDye.Apply(null);
                }
            }
            return true;
        }

        public override void PostDrawTooltipLine(Item item, DrawableTooltipLine line)
        {
            if (item.rare == ExpiryRarity.AcidicRarity)
            {
                if (line.Name == "ItemName")
                {
                    // We don't want the shader to apply to the rest of the tooltips, so we end the spriteBatch here.
                    Main.spriteBatch.End();
                    // Begin the spriteBatch again so the rest of the tooltips can be drawn.
                    // These begin parameters can be found in Main.MouseTextHackZoom() before the tooltips are drawn.
                    Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
                }
            }
            if (item.rare == ExpiryRarity.PrismaticRarity)
            {
                if (line.Name == "ItemName")
                {
                    // We don't want the shader to apply to the rest of the tooltips, so we end the spriteBatch here.
                    Main.spriteBatch.End();
                    // Begin the spriteBatch again so the rest of the tooltips can be drawn.
                    // These begin parameters can be found in Main.MouseTextHackZoom() before the tooltips are drawn.
                    Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
                }
            }
            if (item.rare == ExpiryRarity.VortexRarity)
            {
                if (line.Name == "ItemName")
                {
                    // We don't want the shader to apply to the rest of the tooltips, so we end the spriteBatch here.
                    Main.spriteBatch.End();
                    // Begin the spriteBatch again so the rest of the tooltips can be drawn.
                    // These begin parameters can be found in Main.MouseTextHackZoom() before the tooltips are drawn.
                    Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
                }
            }
        }
    }

    public class ExpiryRarity : GlobalItem
    {
        public static int Expiry = 20;
        public static int AcidicRarity = 21;
        public static int PrismaticRarity = 22;
        public static int VortexRarity = 23;
    }

    public class OnTerrariaHook : GlobalItem
    {
        public bool defAutoReuse;
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
    }
}
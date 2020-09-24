using ExpiryMode.NPCs;
using ReLogic.Reflection;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Util
{
    public class LiquidID
    {
        /// <summary>
        /// Water, a.k.a 0
        /// </summary>
        public const int Water = 0;

        /// <summary>
        /// Lava, a.k.a 1
        /// </summary>
        public const int Lava = 1;

        /// <summary>
        /// Honey, a.k.a 2
        /// </summary>
        public const int Honey = 2;
    }

    public class Arrays_NPCs_Radioactive
    {
        private int[] RadioactiveNPCs =
        {
            NPCType<RadioactiveSlime>(), NPCType<RadioactiveZombie>()
        };
    }

    public class NPCAIStyleID
    {
        public const short None = 0;
        public const short Slime = 1;
        public const short DemonEye = 2;
        public const short Fighter = 3;
        public const short EyeOfCthulhu = 4;

        /// <summary>
        /// Includes things such as Eaters of Souls
        /// </summary>
        public const short Flying = 5;

        public const short Worm = 6;

        /// <summary>
        /// Includes Town NPCs and some ambient creatures, only Town NPCs will have defense with this AI, due to type-based hardcode
        /// </summary>
        public const short Passive = 7;

        public const short Caster = 8;
        public const short Spell = 9;
        public const short CursedSkull = 10;
        public const short SkeletronHead = 11;
        public const short SkeletronHand = 12;
        public const short ManEater = 13;
        public const short Bat = 14;
        public const short KingSlime = 15;
        public const short Piranha = 16;
        public const short Vulture = 17;
        public const short Jellyfish = 18;
        public const short Antlion = 19;

        /// <summary>
        /// For the spike balls in the dungoen, not the projectile
        /// </summary>
        public const short SpikeBall = 20;

        public const short BlazingWheel = 21;

        /// <summary>
        /// Includes enemies such as Wraiths or Ghosts
        /// </summary>
        public const short HoveringFighter = 22;

        /// <summary>
        /// Includes Shadow Hammer and Crimson Axe
        /// </summary>
        public const short EnchantedSword = 23;

        public const short Bird = 24;
        public const short Mimic = 25;
        public const short Unicorn = 26;
        public const short WallOfFleshMouth = 27;
        public const short WallOfFleshEye = 28;
        public const short TheHungry = 29;
        public const short Retinazer = 30;
        public const short Spaazmatism = 31;
        public const short SkeletronPrimeHead = 32;
        public const short PrimeSaw = 33;
        public const short PrimeVice = 34;
        public const short PrimeCannon = 35;
        public const short PrimeLaser = 36;
        public const short TheDestroyer = 37;
        public const short Snowman = 38;

        /// <summary>
        /// Also includes Srollers and Giant Shellies
        /// </summary>
        public const short GiantTortoise = 39;

        /// <summary>
        /// Used for the wall climbing varieants of spiders, the ground variant is <see cref="Fighter"/>
        /// </summary>
        public const short Spider = 40;

        public const short Herpling = 41;

        /// <summary>
        /// Only used for the Lost Girl, nymphs use <see cref="Fighter"/>
        /// </summary>
        public const short LostGirl = 42;

        public const short QueenBee = 43;

        /// <summary>
        /// Also used for Antlion Swarmers
        /// </summary>
        public const short FlyingFish = 44;

        public const short GolemBody = 45;

        /// <summary>
        /// Only used for the unmoving golem head, the moving one is <see cref="FreeGolemHead"/>
        /// </summary>
        public const short GolemHead = 46;

        public const short GolemFist = 47;
        public const short FreeGolemHead = 48;
        public const short AngryNimbus = 49;
        public const short Spore = 50;
        public const short Plantera = 51;
        public const short PlanteraHook = 52;
        public const short PlanteraTentacle = 53;
        public const short BrainOfCthulhu = 54;

        /// <summary>
        /// For the Brain of Cthulhu's minions
        /// </summary>
        public const short Creeper = 55;

        public const short DungeonSpirit = 56;

        /// <summary>
        /// Includes Everscream
        /// </summary>
        public const short MourningWood = 57;

        public const short Pumpking = 58;
        public const short PumpkingScythe = 59;
        public const short IceQueen = 60;
        public const short SantaNK1 = 61;
        public const short ElfCopter = 62;
        public const short Flocko = 63;
        public const short Firefly = 64;
        public const short Butterfly = 65;
        public const short CritterWorm = 66;
        public const short Snail = 67;
        public const short Duck = 68;
        public const short DukeFishron = 69;
        public const short DukeFishronBubble = 70;
        public const short Sharkron = 71;
        public const short BubbleShield = 72;
        public const short TeslaTurret = 73;
        public const short Corite = 74;

        /// <summary>
        /// Includes Drakomire Rider, Dutchman Cannon, Martian Saucer,
        /// Martian Saucer Cannon, Martian Saucer Turret, and Scutlix Gunner
        /// </summary>
        public const short Rider = 75;

        public const short MartianSaucer = 76;
        public const short MoonLordCore = 77;
        public const short MoonLordHand = 78;
        public const short MoonLordHead = 79;
        public const short MartianProbe = 80;
        public const short TrueEyeOfCthulhu = 81;
        public const short MoonLeachClot = 82;
        public const short LunaticDevote = 83;
        public const short LunaticCultist = 84;

        /// <summary>
        /// Includes Brain Sucklers and Deadly Spheres
        /// </summary>
        public const short StarCell = 85;

        public const short AncientVision = 86;
        public const short BiomeMimic = 87;
        public const short Mothron = 88;
        public const short MothronEgg = 89;
        public const short BabyMothron = 90;
        public const short GraniteElemental = 91;
        public const short TargetDummy = 92;
        public const short FlyingDutchman = 93;
        public const short CelestialPillar = 94;
        public const short SmallStarCell = 95;
        public const short FlowInvader = 96;
        public const short NebulaFloater = 97;

        /// <summary>
        /// Stays in place and shoots
        /// </summary>
        public const short Unused0 = 98;

        /// <summary>
        /// The fireball-like "projectiles" shot by the solar pillar
        /// </summary>
        public const short SolarFragment = 99;

        public const short AncientLight = 100;
        public const short AncientDoom = 101;
        public const short SandElemental = 102;
        public const short SandShark = 103;

        /// <summary>
        /// Instantly despawns
        /// </summary>
        public const short Unknown1 = 104;

        public const short DD2EterniaCrystal = 105;
        public const short DD2MysteriousPortal = 106;

        /// <summary>
        /// Used for things such as Etherian Goblins
        /// </summary>
        public const short DD2Fighter = 107;

        /// <summary>
        /// Used for things such as Etherian Wyverns
        /// </summary>
        public const short DD2Flying = 108;

        public const short DD2DarkMage = 109;
        public const short DD2Betsy = 110;
        public const short DD2LightningBug = 111;
    }

    public class ProjectileAIStyleID
    {
        public static readonly IdDictionary Search = IdDictionary.Create<ProjectileAIStyleID, short>();

        /// <summary>
        /// Includes Bullets and Lasers
        /// </summary>
        public const short Arrow = 1;

        /// <summary>
        /// Includes Shurikens, Bones, and Knives
        /// </summary>
        public const short ThrownProjectile = 2;

        public const short Boomerang = 3;
        public const short Vilethorn = 4;
        public const short FallingStar = 5;
        public const short Powder = 6;
        public const short Hook = 7;

        /// <summary>
        /// Includes the Flower of Fire, Waterbolt, Cursed Flame, and Meowmere projectiles
        /// </summary>
        public const short Bounce = 8;

        /// <summary>
        /// Includes Flame Lash and Magic Missile
        /// </summary>
        public const short MagicMissile = 9;

        public const short FallingTile = 10;

        /// <summary>
        /// Includes Shadow Orb and Fairy pets
        /// </summary>
        public const short FloatingFollow = 11;

        /// <summary>
        /// Includes Aqua Scepter and Golden Shower projectiles
        /// </summary>
        public const short Stream = 12;

        public const short Harpoon = 13;

        /// <summary>
        /// Includes most non-destructive Explosive, Glowstick, and Spike Ball projectiles
        /// </summary>
        public const short GroundProjectile = 14;

        public const short Flail = 15;
        public const short Explosive = 16;
        public const short GraveMarker = 17;
        public const short Sickle = 18;
        public const short Spear = 19;

        /// <summary>
        /// Includes Saws
        /// </summary>
        public const short Drill = 20;

        public const short MusicNote = 21;
        public const short IceRod = 22;

        /// <summary>
        /// Includes Flamethrower Flames, Cursed Flames, and Eye Fire
        /// </summary>
        public const short Flames = 23;

        public const short CrystalShard = 24;
        public const short Boulder = 25;

        /// <summary>
        /// Includes some minions with simple AI, such as the Baby Slime
        /// </summary>
        public const short Pet = 26;

        public const short Beam = 27;

        /// <summary>
        /// Includes Ice Sword, Frost Hydra, Frost Bolt, and Icy Spit projectiles
        /// </summary>
        public const short ColdBolt = 28;

        public const short GemStaffBolt = 29;
        public const short Mushroom = 30;
        public const short Spray = 31;
        public const short BeachBall = 32;
        public const short Flare = 33;
        public const short FireWork = 34;
        public const short RopeCoil = 35;

        /// <summary>
        /// Includes Bee, Wasp, Tiny Eater, and Bat projectiles
        /// </summary>
        public const short SmallFlying = 36;

        public const short SpearTrap = 37;
        public const short FlameThrower = 38;
        public const short MechanicalPiranha = 39;
        public const short Leaf = 40;
        public const short FlowerPetal = 41;
        public const short CrystalLeaf = 42;
        public const short CrystalLeafShot = 43;

        /// <summary>
        /// Moves a short distance and then stops, includes Spore Cloud, Chlorophyte Orb, and Storm Spear Shot projectiles
        /// </summary>
        public const short MoveShort = 44;

        public const short RainCloud = 45;
        public const short Rainbow = 46;
        public const short MagnetSphere = 47;
        public const short Ray = 48;
        public const short ExplosiveBunny = 49;
        public const short Inferno = 50;
        public const short LostSoul = 51;

        /// <summary>
        /// Includes Spirit Heal from the Spectre Hood and Vampire Heal from the Vampire Knives
        /// </summary>
        public const short Heal = 52;

        public const short FrostHydra = 53;
        public const short Raven = 54;
        public const short FlamingJack = 55;
        public const short FlamingScythe = 56;
        public const short NorthPoleSpear = 57;
        public const short Present = 58;
        public const short SpectreWrath = 59;
        public const short WaterJet = 60;
        public const short Bobber = 61;
        public const short Hornet = 62;
        public const short BabySpider = 63;

        /// <summary>
        /// Includes Sharknado and Cthulunado projectiles
        /// </summary>
        public const short Nado = 64;

        public const short SharknadoBolt = 65;
        public const short MiniTwins = 66;

        /// <summary>
        /// Includes Mini Pirate, Crimson Heart, Companion Cube, Vampire Frog, and Desert Tiger projectiles
        /// </summary>
        public const short CommonFollow = 67;

        public const short MolotovCocktail = 68;
        public const short Flairon = 69;
        public const short FlaironBubble = 70;
        public const short Typhoon = 71;
        public const short Bubble = 72;
        public const short FireWorkFountain = 73;
        public const short ScutlixLaser = 74;
        public const short HeldProjectile = 75;
        public const short Crosshair = 76;
        public const short Electrosphere = 77;
        public const short Xenopopper = 78;
        public const short MartianDeathRay = 79;
        public const short MartianRocket = 80;
        public const short InfluxWaver = 81;
        public const short PhantasmalEye = 82;
        public const short PhantasmalSphere = 83;

        /// <summary>
        /// Includes Charged Laser Blaster, Stardust Laser, Last Prism, and Lunar Portal Laser projectiles
        /// </summary>
        public const short ThickLaser = 84;

        public const short MoonLeech = 85;
        public const short IceMist = 86;
        public const short CursedFlameWall = 87;
        public const short LightningOrb = 88;
        public const short LightningRitual = 89;
        public const short MagicLantern = 90;
        public const short ShadowFlame = 91;
        public const short ToxicCloud = 92;
        public const short Nail = 93;
        public const short CoinPortal = 94;
        public const short ToxicBubble = 95;
        public const short IchorSplash = 96;
        public const short FlyingPiggyBank = 97;
        public const short MysteriousTablet = 98;
        public const short Yoyo = 99;
        public const short MedusaRay = 100;

        /// <summary>
        /// Includes Medusa Head Ray and Mechanical Cart Laser projectiles
        /// </summary>
        public const short HorizontalRay = 101;

        /// <summary>
        /// Includes Flow Invader, Nebular Piercer, and Nebula Eye projectiles
        /// </summary>
        public const short LunarProjectile = 102;

        public const short Starmark = 103;
        public const short BrainofConfusion = 104;
        public const short SporeTrap = 105;
        public const short SporeGas = 106;

        /// <summary>
        /// Includes Desert Sprit's Curse
        /// </summary>
        public const short NebulaSphere = 107;

        /// <summary>
        /// Includes Blood Tears
        /// </summary>
        public const short Vortex = 108;

        public const short MechanicWrench = 109;
        public const short NurseSyringe = 110;
        public const short DryadWard = 111;

        /// <summary>
        /// Includes Truffle Spore, Rainbow Crystal Explosion, and Dandelion Seed projectiles
        /// </summary>
        public const short SmallProximityExplosion = 112;

        /// <summary>
        /// Includes Bone Javelin, Stardust Cell Shot, and Daybreak projectiles
        /// </summary>
        public const short StickProjectile = 113;

        public const short PortalGate = 114;
        public const short TerrarianBeam = 115;
        public const short DrakomiteFlare = 116;

        /// <summary>
        /// Includes Solar Radience and Solar Eruption Explosion projectiles
        /// </summary>
        public const short SolarEffect = 117;

        public const short NebulaArcanum = 118;
        public const short ArcanumSubShot = 119;
        public const short StardustGuardian = 120;
        public const short StardustDragon = 121;

        /// <summary>
        /// The effect displayed when killing a Lunar Event enemy while it's respective Celestial Pillar is alive, also used by Phantasm Arrow
        /// </summary>
        public const short ReleasedEnergy = 122;

        public const short LunarSentry = 123;

        /// <summary>
        /// Includes Suspicious Looking Tentacle, Suspicious Eye, Rez and Spaz, Fairy Princess, Jack 'O Lantern, and Ice Queen pets
        /// </summary>
        public const short FloatInFrontPet = 124;

        public const short WireKite = 125;
        public const short Geyser = 126;
        public const short AncientStorm = 127;
        public const short AncientStormMark = 128;
        public const short SpiritFlame = 129;
        public const short DD2FlameBurst = 130;
        public const short DD2FlameBurstShot = 131;

        /// <summary>
        /// Eternia Crystal destroyed
        /// </summary>
        public const short DD2GrimEnd = 132;

        public const short DD2DarkSigil = 133;
        public const short DD2Ballista = 134;

        /// <summary>
        /// Includes Ogre's Stomp and Geyser projectiles
        /// </summary>
        public const short UpwardExpand = 135;

        public const short DD2BetsysBreath = 136;
        public const short DD2LightningAura = 137;
        public const short DD2ExplosiveTrap = 138;
        public const short DD2ExplosiveTrapExplosion = 139;
        public const short SleepyOctopod = 140;

        /// <summary>
        /// The effect created on use of the Sleepy Octopod
        /// </summary>
        public const short PoleSmash = 141;

        /// <summary>
        /// Use style of the Ghastly Glaive and Sky Dragon's Fury alt1
        /// </summary>
        public const short ForwardStab = 142;

        public const short Ghast = 143;

        /// <summary>
        /// Includes the Hoardragon, Flickerwick, Estee, and Propeller Gato
        /// </summary>
        public const short FloatBehindPet = 144;

        public const short WisdomWhirlwind = 145;

        /// <summary>
        /// Old One's Army defeated
        /// </summary>
        public const short DD2Victory = 146;
    }
}

namespace Microsoft.Xna.Framework
{
    public class ExpiryColor
    {
        public static Color BrightChartreuse = new Color(173, 204, 182);
    }
}
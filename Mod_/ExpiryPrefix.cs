using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Mod_
{
    public class Warm : ModPrefix
    {
        public override void Apply(Item item)
        {
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Warm");
        }

        public override float RollChance(Item item)
               => 1.5f;

        public override bool CanRoll(Item item)
            => true;

        public override PrefixCategory Category
            => PrefixCategory.Accessory;

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.1f;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            Player player = Main.player[Main.myPlayer];
            player.buffImmune[BuffID.Chilled] = true;
        }
    }

    public class Almighty : ModPrefix
    {
        public override void Apply(Item item)
        {
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Almighty");
        }

        public override float RollChance(Item item)
               => .95f;

        public override bool CanRoll(Item item)
            => true;

        public override PrefixCategory Category
            => PrefixCategory.Melee;

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.35f;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.3f;
            useTimeMult = 1.3f;
        }
    }

    public class Healthy : ModPrefix
    {
        public override void Apply(Item item)
        {
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Healthy");
        }

        public override float RollChance(Item item)
               => 0.60f;

        public override bool CanRoll(Item item)
            => Main.hardMode ? true : false;

        public override PrefixCategory Category
            => PrefixCategory.Accessory;

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.70f;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            Player player = Main.player[Main.myPlayer];
            player.statLifeMax2 += 50;
        }
    }
}
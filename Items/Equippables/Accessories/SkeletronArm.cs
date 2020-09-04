using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ExpiryMode.Global_;
using ExpiryMode.Mod_;

namespace ExpiryMode.Items.Equippables.Accessories
{
	public class SkeletronArm : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Skeletron's Arm");
			Tooltip.SetDefault("Makes weak skeletons not want to attack you\n'You are superior to them'");
		}
		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
            item.value = 12317;
			item.accessory = true;
			item.rare = ExpiryRarity.Expiry;
		}
		public override void UpdateEquip(Player player) 
		{
			player.npcTypeNoAggro[NPCID.Skeleton] = true;
			player.npcTypeNoAggro[NPCID.HeadacheSkeleton] = true;
			player.npcTypeNoAggro[NPCID.MisassembledSkeleton] = true;
			player.npcTypeNoAggro[NPCID.PantlessSkeleton] = true;
			player.npcTypeNoAggro[NPCID.ArmoredSkeleton] = true;
			player.npcTypeNoAggro[NPCID.UndeadMiner] = true;
			player.npcTypeNoAggro[NPCID.AngryBones] = true;
			player.npcTypeNoAggro[NPCID.AngryBonesBig] = true;
			player.npcTypeNoAggro[NPCID.AngryBonesBigHelmet] = true;
			player.npcTypeNoAggro[NPCID.AngryBonesBigMuscle] = true;
			player.npcTypeNoAggro[NPCID.BoneThrowingSkeleton] = true;
			player.npcTypeNoAggro[NPCID.BoneThrowingSkeleton2] = true;
			player.npcTypeNoAggro[NPCID.BoneThrowingSkeleton3] = true;
            player.npcTypeNoAggro[NPCID.BoneThrowingSkeleton4] = true;
            player.npcTypeNoAggro[NPCID.DarkCaster] = true;
			// TODO: Make Dark Caster Bolts Not hurt you/Cast at you
		}
	}
}
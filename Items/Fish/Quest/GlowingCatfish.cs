using ExpiryMode.Mod_;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExpiryMode.Items.Fish.Quest
{
	public class GlowingCatfish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Catfish");
		}

		public override void SetDefaults()
		{
			item.questItem = true;
			item.maxStack = 1;
			item.width = 26;
			item.height = 26;
			item.uniqueStack = true;
            item.rare = ItemRarityID.Quest;
		}

		public override bool IsQuestFish()
		{
			return true;
		}
		public override bool IsAnglerQuestAvailable()
		{
			return SuffWorld.ExpiryModeIsActive;
		}
		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "Have you seen that biome? That place is as deadly as ever... Which is exactly why I'm sending you on a mission to go catch this fish!"
				+ " I've heard that the fish there have their guts exposed from the immense radiation emitted from that area. Seems like a good spot to get my hands into."
				+ " Now get over there and catch it before I call you a wimp!";
			catchLocation = "Caught in the Radiance";
		}
	}
}
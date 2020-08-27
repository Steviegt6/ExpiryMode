using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using ExpiryMode.Mod_;
using System.Linq;
using System;
using System.Net.NetworkInformation;
using IL.Terraria.Localization;

namespace ExpiryMode.Items.Useables
{
	public class ChaliceofDeath : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chalice of Demise");
			Tooltip.SetDefault("Enables Expiry Mode\nBe aware. You can only use this item once. If you enable the mode, you cannot disable it ever again in this world.\nBefore you use it, you must be absolutely sure that you want to enable the mode.");
		}

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item119;
            item.autoReuse = false;
        }
        public override void HoldItem(Player player)
        {
        }
        public override bool UseItem(Player player)
        {
			if (!SuffWorld.ExpiryModeIsActive)
            {
                SuffWorld.ExpiryModeIsActive = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                    SuffWorld.ExpiryModeIsActive = true;
                }
                Main.NewText("Expiry Mode has been enabled. Be ready for some real hell.", Color.DarkOrange, true);
            }
            else if (SuffWorld.ExpiryModeIsActive)
            {
                SuffWorld.ExpiryModeIsActive = false;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                    SuffWorld.ExpiryModeIsActive = false;
                }
                Main.NewText("Expiry Mode has been disabled. Not that much of a man, I see.", Color.Orange, true);
            }
			return true;
        }
		public override bool CanUseItem(Player player)
		{
            return /*!Main.npc.Any(n => n.active && n.boss);*/ !SuffWorld.ExpiryModeIsActive;
        }
	}
}
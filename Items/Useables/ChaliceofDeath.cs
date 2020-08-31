using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using ExpiryMode.Mod_;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace ExpiryMode.Items.Useables
{
	public class ChaliceofDeath : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chalice of Demise");
            Tooltip.SetDefault("HahaFunny");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 7)); // Note: TicksPerFrame, Frames
        }
        /// <summary>
        /// Where the gayass properties are set.
        /// </summary>
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
            //item.noUseGraphic = true;
            //item.shoot = ProjectileType<Projectiles.ChaliceOfDeath>();  
        }
        /*public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            //return spriteBatch.Draw(GetTexture("ExpiryMode/Items/Useables/ChaliceofDeathAnim"), )
            Texture2D texture = Main.itemTexture[item.type];
            for (int i = 0; i < 4; i++)
            {
                Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
                spriteBatch.Draw(GetTexture("ExpiryMode/Items/Useables/ChaliceofDeathAnim"), position, frame, drawColor, 0, origin, scale, SpriteEffects.None, 0f);
            }
            return true;
        }*/
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
                    NetMessage.SendData(MessageID.RequestWorldInfo);
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
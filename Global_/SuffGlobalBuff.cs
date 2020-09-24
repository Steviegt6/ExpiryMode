using Terraria;
using Terraria.ModLoader;

namespace ExpiryMode.Global_
{
    public class SuffGlobalBuff : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            /*if (Main.GameUpdateCount % 2 == 0)
            {
                player.AddBuff(type, SuffWorld.ExpiryModeIsActive ? player.buffTime[buffIndex] * 2 : player.buffTime[buffIndex]);
            }*/
            /*if (SuffWorld.ExpiryModeIsActive && Main.GameUpdateCount % 2 == 0)
            {
                player.buffTime[buffIndex]++;
            }*/
        }
    }
}
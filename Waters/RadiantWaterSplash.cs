using Terraria;
using Terraria.ModLoader;
 
namespace ExpiryMode.Waters
{
    public class RadiantWaterSplash : ModDust
    {
        public override void SetDefaults()
        {
            updateType = 33; // Copy defaults of another DustID
        }
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 170; // The higher you go with this field, the more transparent the dust gets
            dust.velocity *= 0.9f;  // The default pixels travelled/tick
            dust.velocity.Y += 1f;  // The velocity of this dust when shot up
        }
    }
}
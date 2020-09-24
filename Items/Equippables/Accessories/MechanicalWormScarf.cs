using ExpiryMode.Global_;
using ExpiryMode.Mod_;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpiryMode.Items.Equippables.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class MechanicalWormScarf : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Worm Scarf");
            Tooltip.SetDefault("Reduces all damage by 25%\nDoes not stack with the worm scarf\n'I fought tooth and nail for this'");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = 32113;
            item.accessory = true;
            item.rare = ExpiryRarity.Expiry;
        }

        public override bool CanEquipAccessory(Player player, int slot)
        {
            if (slot < 10) // This allows the accessory to equip in Vanity slots with no reservations.
            {
                int maxAccessoryIndex = 5 + player.extraAccessorySlots;
                for (int slots = 3; slots < 3 + maxAccessoryIndex; slots++)
                {
                    // We need "slot != i" because we don't care what is currently in the slot we will be replacing.
                    if (slot != slots && player.armor[slots].type == ItemID.WormScarf)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<InfiniteSuffPlayer>().mechScarf = true;
            player.endurance += 0.25f;
        }
    }
}
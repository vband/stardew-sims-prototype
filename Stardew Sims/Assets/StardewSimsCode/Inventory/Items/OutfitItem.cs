using UnityEngine;

namespace StardewSimsCode.Inventory.Items
{
    [CreateAssetMenu(fileName = "NewOutfitItem", menuName = "StardewSims/Inventory/OutfitItem")]
    public class OutfitItem : WearableItem
    {
        public override void Equip(Inventory inventory)
        {
            if (inventory.IsEquippingOutfit())
            {
                if (inventory.GetFreeSpacesCount() == 0
                    || !inventory.TryGetFirstFreeSpaceIndex(out var freeSpaceIndex))
                {
                    inventory.DropItem(inventory.Outfit);
                    inventory.UnequipOutfit();
                    return;
                }

                inventory.Items[freeSpaceIndex] = inventory.Outfit;
                
                inventory.UnequipOutfit();
            }
            
            inventory.EquipOutfit(this);
        }
    }
}
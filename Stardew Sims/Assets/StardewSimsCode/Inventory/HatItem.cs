using UnityEngine;

namespace StardewSimsCode.Inventory
{
    [CreateAssetMenu(fileName = "NewHatItem", menuName = "StardewSims/Inventory/HatItem")]
    public class HatItem : WearableItem
    {
        public override void Equip(Inventory inventory)
        {
            if (inventory.IsEquippingHat())
            {
                if (inventory.GetFreeSpacesCount() == 0
                    || !inventory.TryGetFirstFreeSpaceIndex(out var freeSpaceIndex))
                {
                    inventory.DropItem(inventory.Hat);
                    inventory.UnequipHat();
                    return;
                }

                inventory.Items[freeSpaceIndex] = inventory.Hat;
                
                inventory.UnequipHat();
            }
            
            inventory.EquipHat(this);
        }
    }
}
using StardewSimsCode.Inventory.Items;
using UnityEngine;

namespace StardewSimsCode.Inventory
{
    [CreateAssetMenu(fileName = "NewInventory", menuName = "StardewSims/Inventory/Inventory")]
    public class Inventory : ScriptableObject
    {
        public Item[] Items { get; } = new Item[10];
        public OutfitItem Outfit { get; private set; }
        public HairItem Hair { get; private set; }
        public HatItem Hat { get; private set; }

        public delegate void OnInventoryChangedDelegate();
        public event OnInventoryChangedDelegate InventoryChanged;

        public delegate void OnDroppedItem(Item droppedItem);
        public event OnDroppedItem DroppedItem;

        public int GetFreeSpacesCount()
        {
            var freeSpaces = 0;
            for (var i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                    freeSpaces++;
            }

            return freeSpaces;
        }

        public bool TryGetFirstFreeSpaceIndex(out int freeSpaceIndex)
        {
            freeSpaceIndex = -1;

            if (GetFreeSpacesCount() == 0)
                return false;

            for (var i = 0; i < Items.Length; i++)
            {
                if (Items[i] != null)
                    continue;
                
                freeSpaceIndex = i;
                return true;
            }

            return false;
        }

        public bool IsEquippingOutfit()
        {
            return Outfit != null;
        }

        public bool IsEquippingHair()
        {
            return Hair != null;
        }

        public bool IsEquippingHat()
        {
            return Hat != null;
        }

        public void EquipOutfit(OutfitItem outfit)
        {
            Outfit = outfit;
            InventoryChanged?.Invoke();
        }
        
        public void EquipHair(HairItem hair)
        {
            Hair = hair;
            InventoryChanged?.Invoke();
        }
        
        public void EquipHat(HatItem hat)
        {
            Hat = hat;
            InventoryChanged?.Invoke();
        }

        public void UnequipOutfit()
        {
            if (!IsEquippingOutfit())
                return;

            Outfit = null;
            
            InventoryChanged?.Invoke();
        }
        
        public void UnequipHair()
        {
            if (!IsEquippingHair())
                return;

            Hair = null;
            
            InventoryChanged?.Invoke();
        }
        
        public void UnequipHat()
        {
            if (!IsEquippingHat())
                return;

            Hat = null;
            
            InventoryChanged?.Invoke();
        }

        public void DropItem(Item item)
        {
            DroppedItem?.Invoke(item);
        }

        public void AddItem(int index, Item item)
        {
            Items[index] = item;
            InventoryChanged?.Invoke();
        }
    }
}
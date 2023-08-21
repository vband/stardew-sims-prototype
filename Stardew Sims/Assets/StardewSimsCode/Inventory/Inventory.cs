using StardewSimsCode.GlobalEvents;
using StardewSimsCode.Inventory.Items;
using UnityEngine;

namespace StardewSimsCode.Inventory
{
    [CreateAssetMenu(fileName = "NewInventory", menuName = "StardewSims/Inventory/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField] private GlobalEvent _onDroppedItemGlobalEvent;
        
        [SerializeField] private Item[] _items = new Item[10];
        [SerializeField] private OutfitItem _outfit = null;
        [SerializeField] private HairItem _hair = null;
        [SerializeField] private HatItem _hat = null;

        public Item[] Items => _items;
        public OutfitItem Outfit => _outfit;
        public HairItem Hair => _hair;
        public HatItem Hat => _hat;

        public delegate void OnInventoryChangedDelegate();
        public event OnInventoryChangedDelegate InventoryChanged;

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
            _outfit = outfit;
            InventoryChanged?.Invoke();
        }
        
        public void EquipHair(HairItem hair)
        {
            _hair = hair;
            InventoryChanged?.Invoke();
        }
        
        public void EquipHat(HatItem hat)
        {
            _hat = hat;
            InventoryChanged?.Invoke();
        }

        public void UnequipOutfit()
        {
            if (!IsEquippingOutfit())
                return;

            _outfit = null;
            
            InventoryChanged?.Invoke();
        }
        
        public void UnequipHair()
        {
            if (!IsEquippingHair())
                return;

            _hair = null;
            
            InventoryChanged?.Invoke();
        }
        
        public void UnequipHat()
        {
            if (!IsEquippingHat())
                return;

            _hat = null;
            
            InventoryChanged?.Invoke();
        }

        public void DropItem(Item item)
        {
            _onDroppedItemGlobalEvent.Trigger(item);
        }

        public void SetItemAtIndex(int index, Item item)
        {
            Items[index] = item;
            InventoryChanged?.Invoke();
        }

        public void RemoveItemFromIndex(int index)
        {
            if (index < 0 || index >= Items.Length || Items[index] == null)
                return;

            Items[index] = null;
            InventoryChanged?.Invoke();
        }
    }
}
﻿using StardewSimsCode.Inventory.Items;

namespace StardewSimsCode.Inventory.Views
{
    public class InterfaceHatView : InterfaceItemView
    {
        public override Item Item => _inventory.Hat;
        
        public override bool TrySetItem(Item item)
        {
            if (item is not HatItem hatItem)
                return false;

            _inventory.EquipHat(hatItem);
            return true;
        }
        
        public override void RemoveItem()
        {
            _inventory.UnequipHat();
        }
    }
}
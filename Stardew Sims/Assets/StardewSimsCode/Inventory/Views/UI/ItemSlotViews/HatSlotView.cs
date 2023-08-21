using StardewSimsCode.Inventory.Items;

namespace StardewSimsCode.Inventory.Views.UI.ItemSlotViews
{
    public class HatSlotView : ItemSlotView
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
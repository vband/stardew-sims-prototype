using StardewSimsCode.Inventory.Items;

namespace StardewSimsCode.Inventory.Views.UI.ItemSlotViews
{
    public class HairSlotView : ItemSlotView
    {
        public override Item Item => _inventory.Hair;

        public override bool TrySetItem(Item item)
        {
            if (item is not HairItem hairItem)
                return false;

            _inventory.EquipHair(hairItem);
            return true;
        }
        
        public override void RemoveItem()
        {
            _inventory.UnequipHair();
        }
    }
}
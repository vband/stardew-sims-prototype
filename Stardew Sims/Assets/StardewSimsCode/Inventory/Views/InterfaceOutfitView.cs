using StardewSimsCode.Inventory.Items;

namespace StardewSimsCode.Inventory.Views
{
    public class InterfaceOutfitView : InterfaceItemView
    {
        public override bool TrySetItem(Item item)
        {
            if (item is not OutfitItem)
                return false;

            _item = item;
            return true;
        }
    }
}
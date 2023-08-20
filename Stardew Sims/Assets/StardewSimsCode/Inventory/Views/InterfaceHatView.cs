using StardewSimsCode.Inventory.Items;

namespace StardewSimsCode.Inventory.Views
{
    public class InterfaceHatView : InterfaceItemView
    {
        public override bool TrySetItem(Item item)
        {
            if (item is not HatItem)
                return false;

            _item = item;
            return true;
        }
    }
}
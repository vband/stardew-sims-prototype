using StardewSimsCode.Inventory.Items;

namespace StardewSimsCode.Inventory.Views
{
    public class InterfaceHairView : InterfaceItemView
    {
        public override bool TrySetItem(Item item)
        {
            if (item is not HairItem)
                return false;

            _item = item;
            return true;
        }
    }
}
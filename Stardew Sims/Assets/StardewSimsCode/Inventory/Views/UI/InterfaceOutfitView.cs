using StardewSimsCode.Inventory.Items;

namespace StardewSimsCode.Inventory.Views.UI
{
    public class InterfaceOutfitView : InterfaceItemView
    {
        public override Item Item => _inventory.Outfit;

        public override bool TrySetItem(Item item)
        {
            if (item is not OutfitItem outfitItem)
                return false;

            _inventory.EquipOutfit(outfitItem);
            return true;
        }

        public override void RemoveItem()
        {
            _inventory.UnequipOutfit();
        }
    }
}
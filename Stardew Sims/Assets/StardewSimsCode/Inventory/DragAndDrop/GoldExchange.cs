using StardewSimsCode.Inventory.Items;

namespace StardewSimsCode.Inventory.DragAndDrop
{
    public class GoldExchange
    {
        public static void TransferGold(Inventory originInventory, Inventory destinationInventory, Item transferredItem)
        {
            var itemPrice = transferredItem.Price;
            originInventory.Gold += itemPrice;
            destinationInventory.Gold -= itemPrice;
        }

        public static bool CanAfford(Inventory receivingInventory, Item purchasedItem)
        {
            return receivingInventory.Gold >= purchasedItem.Price;
        }
    }
}
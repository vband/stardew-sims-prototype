using StardewSimsCode.Inventory.Items;
using StardewSimsCode.Inventory.Views.UI;
using StardewSimsCode.Inventory.Views.UI.ItemSlotViews;

namespace StardewSimsCode.Inventory.DragAndDrop
{
    [System.Serializable]
    public struct DragData
    {
        public Item ItemBeingDragged;
        public ItemSlotView OriginSlot;
        public ItemSlotView DestinationSlot;
    }
}
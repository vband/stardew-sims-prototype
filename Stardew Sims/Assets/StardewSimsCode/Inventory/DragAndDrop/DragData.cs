using StardewSimsCode.Inventory.Items;
using StardewSimsCode.Inventory.Views.UI;

namespace StardewSimsCode.Inventory.DragAndDrop
{
    [System.Serializable]
    public struct DragData
    {
        public Item ItemBeingDragged;
        public InterfaceItemView OriginSlot;
        public InterfaceItemView DestinationSlot;
    }
}
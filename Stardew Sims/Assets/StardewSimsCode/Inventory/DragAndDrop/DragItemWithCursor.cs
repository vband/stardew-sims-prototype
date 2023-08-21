using StardewSimsCode.Inventory.Items;
using StardewSimsCode.Inventory.Views.UI.ItemSlotViews;
using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace StardewSimsCode.Inventory.DragAndDrop
{
    public class DragItemWithCursor : MonoBehaviour
    {
        [SerializeField] private RectTransform _draggedRectTransform;
        [SerializeField] private Image _draggedImage;
        [SerializeField] private SerializedDragData _dragData;
        
        private bool _isDragging;
        
        public void OnStartDrag()
        {
            _isDragging = true;
            _draggedImage.sprite = _dragData.Value.ItemBeingDragged.InventorySprite;
        }

        public void OnEndDrag()
        {
            _isDragging = false;

            var originSlot = _dragData.Value.OriginSlot;
            var destinationSlot = _dragData.Value.DestinationSlot;
            var itemBeingDragged = _dragData.Value.ItemBeingDragged;

            if (destinationSlot == null)
            {
                // Drop dragged item on world
                originSlot.Inventory.DropItem(itemBeingDragged);
                return;
            }

            if (destinationSlot.Item == null)
            {
                // Place dragged item at other slot. If unable, leave it at origin slot
                if (CannotCompletePurchase(destinationSlot, itemBeingDragged, originSlot)
                    || !destinationSlot.TrySetItem(itemBeingDragged))
                {
                    PlaceItemAtOriginSlot(originSlot, itemBeingDragged);
                    return;
                }
                
                GoldExchange.TransferGold(originSlot.Inventory, destinationSlot.Inventory, itemBeingDragged);
                destinationSlot.UpdateView();
                
                return;
            }

            var destinationSlotInitialItem = destinationSlot.Item;
            
            // Swap items between slots. If unable, leave dragged item at origin slot
            if (CannotCompleteTrade(originSlot, destinationSlot, itemBeingDragged)
                || !originSlot.TrySetItem(destinationSlot.Item)
                || !destinationSlot.TrySetItem(itemBeingDragged))
            {
                PlaceItemAtOriginSlot(originSlot, itemBeingDragged);
                return;
            }
            
            GoldExchange.TransferGold(originSlot.Inventory, destinationSlot.Inventory, itemBeingDragged);
            GoldExchange.TransferGold(destinationSlot.Inventory, originSlot.Inventory, destinationSlotInitialItem);
            originSlot.UpdateView();
            destinationSlot.UpdateView();
        }

        private static bool CannotCompleteTrade(ItemSlotView originSlot, ItemSlotView destinationSlot, Item itemBeingDragged)
        {
            return (originSlot.Inventory != destinationSlot.Inventory
                    && (!GoldExchange.CanAfford(originSlot.Inventory, destinationSlot.Item)
                        || !GoldExchange.CanAfford(destinationSlot.Inventory, itemBeingDragged)));
        }

        private static bool CannotCompletePurchase(ItemSlotView destinationSlot, Item itemBeingDragged, ItemSlotView originSlot)
        {
            return (!GoldExchange.CanAfford(destinationSlot.Inventory, itemBeingDragged)
                    && originSlot.Inventory != destinationSlot.Inventory);
        }

        private static void PlaceItemAtOriginSlot(ItemSlotView originSlot, Item itemBeingDragged)
        {
            originSlot.TrySetItem(itemBeingDragged);
            originSlot.UpdateView();
        }

        private void Update()
        {
            if (!_isDragging)
                return;

            MoveItemImageWithCursor();
        }

        private void MoveItemImageWithCursor()
        {
            var mousePos = Mouse.current.position.ReadValue();
            _draggedRectTransform.position = mousePos;
        }
    }
}
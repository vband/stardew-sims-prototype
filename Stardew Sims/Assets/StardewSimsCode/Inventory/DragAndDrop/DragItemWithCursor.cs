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
                if (!destinationSlot.TrySetItem(itemBeingDragged))
                {
                    PlaceItemAtOriginSlot(originSlot, itemBeingDragged);
                }
                destinationSlot.UpdateView();
                
                return;
            }

            // Swap items between slots. If unable, leave dragged item at origin slot
            if (!originSlot.TrySetItem(destinationSlot.Item) || !destinationSlot.TrySetItem(itemBeingDragged))
            {
                PlaceItemAtOriginSlot(originSlot, itemBeingDragged);
                return;
            }
            originSlot.UpdateView();
            destinationSlot.UpdateView();
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
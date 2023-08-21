using StardewSimsCode.GlobalEvents;
using StardewSimsCode.Inventory.DragAndDrop;
using StardewSimsCode.Inventory.Items;
using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;
using UnityEngine.UI;

namespace StardewSimsCode.Inventory.Views.UI
{
    public class InterfaceItemView : MonoBehaviour
    {
        [SerializeField] private int _inventoryIndex;
        [SerializeField] protected Image _image;
        [SerializeField] protected Inventory _inventory;
        [SerializeField] protected GlobalEvent _onBeginDragGlobalEvent;
        [SerializeField] protected GlobalEvent _onEndDragGlobalEvent;
        [SerializeField] protected SerializedDragData _dragData;
        
        public virtual Item Item => _inventory.Items[_inventoryIndex];
        public Inventory Inventory => _inventory;
        public int InventoryIndex => _inventoryIndex;
        public bool IsActive => Item != null;

        private void Start()
        {
            UpdateView();
        }

        private void OnEnable()
        {
            _inventory.InventoryChanged += UpdateView;
        }

        private void OnDisable()
        {
            _inventory.InventoryChanged -= UpdateView;
        }

        public virtual bool TrySetItem(Item item)
        {
            _inventory.SetItemAtIndex(_inventoryIndex, item);
            return true;
        }

        public virtual void RemoveItem()
        {
            _inventory.RemoveItemFromIndex(_inventoryIndex);
        }

        public void UpdateView()
        {
            if (!IsActive)
            {
                SetUpInactiveSlot();
                return;
            }

            SetUpActiveSlot();
        }

        private void SetUpActiveSlot()
        {
            _image.sprite = Item.InventorySprite;
            _image.color = new Color(1, 1, 1, 1);
        }

        private void SetUpInactiveSlot()
        {
            _image.sprite = null;
            _image.color = new Color(1, 1, 1, 0);
        }

        public void OnBeginDrag()
        {
            if (!IsActive)
                return;

            _dragData.SetValue(new DragData
            {
                ItemBeingDragged = Item,
                OriginSlot = this
            });

            RemoveItem();
            _onBeginDragGlobalEvent.Trigger(null);
        }

        public void OnEndDrag()
        {
            _onEndDragGlobalEvent.Trigger(null);
        }

        public void OnDrop()
        {
            _dragData.SetValue(new DragData
            {
                ItemBeingDragged = _dragData.Value.ItemBeingDragged,
                OriginSlot = _dragData.Value.OriginSlot,
                DestinationSlot = this
            });
        }
    }
}
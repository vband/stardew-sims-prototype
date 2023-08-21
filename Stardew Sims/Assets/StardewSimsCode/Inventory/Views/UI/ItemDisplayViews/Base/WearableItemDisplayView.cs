using UnityEngine;
using UnityEngine.UI;

namespace StardewSimsCode.Inventory.Views.UI.ItemDisplayViews.Base
{
    public abstract class WearableItemDisplayView : MonoBehaviour
    {
        [SerializeField] protected Inventory _inventory;
        [SerializeField] protected Image _image;

        protected abstract void UpdateImage();

        private void Start()
        {
            UpdateImage();
        }

        private void OnEnable()
        {
            _inventory.InventoryChanged += OnInventoryChanged;
        }

        private void OnDisable()
        {
            _inventory.InventoryChanged -= OnInventoryChanged;
        }

        private void OnInventoryChanged()
        {
            UpdateImage();
        }
        
        protected void SetUpEquippedColor()
        {
            _image.color = new Color(1, 1, 1, 1);
        }
        
        protected void SetUpEmptyPiece()
        {
            _image.sprite = null;
            _image.color = new Color(1, 1, 1, 0);
        }
    }
}
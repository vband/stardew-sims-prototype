using StardewSimsCode.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace StardewSimsCode.Inventory.Views
{
    public class InterfaceItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Item _item;

        private bool _isActive;

        public bool IsActive => _isActive;

        public void SetItem(Item item)
        {
            _item = item;
        }

        public void UpdateView()
        {
            if (_item == null)
            {
                _isActive = false;
                _image.sprite = null;
                
                // Transparent
                _image.color = new Color(1, 1, 1, 0);
                return;
            }

            _isActive = true;
            _image.sprite = _item.InventorySprite;
            
            // Not transparent
            _image.color = new Color(1, 1, 1, 1);
        }
    }
}
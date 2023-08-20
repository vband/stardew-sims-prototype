using StardewSimsCode.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace StardewSimsCode.Inventory.Views
{
    public class InterfaceItemView : MonoBehaviour
    {
        [SerializeField] protected Image _image;
        [SerializeField] protected Item _item;

        protected bool _isActive;

        public bool IsActive => _isActive;

        public virtual bool TrySetItem(Item item)
        {
            _item = item;
            return true;
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
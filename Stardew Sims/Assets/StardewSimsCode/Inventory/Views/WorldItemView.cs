using UnityEngine;

namespace StardewSimsCode.Inventory.Views
{
    public class WorldItemView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Item _item;

        public Item Item => _item;

        public void SetItem(Item item)
        {
            _item = item;
        }

        private void Start()
        {
            if (_spriteRenderer == null)
            {
                Debug.LogError($"{_spriteRenderer.name} is null");
                return;
            }
            
            if (_item == null)
            {
                Debug.LogError($"{_item.name} is null");
                return;
            }
            
            _spriteRenderer.sprite = _item.WorldSprite;
        }
    }
}
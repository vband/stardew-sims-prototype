using StardewSimsCode.Inventory.Views;
using UnityEngine;

namespace StardewSimsCode.Inventory.Behaviours
{
    public class CollectWorldItems : MonoBehaviour
    {
        [SerializeField] private Inventory _playerInventory;

        private void OnCollisionEnter2D(Collision2D col)
        {
            var worldItem = col.gameObject.GetComponent<WorldItemView>();

            if (worldItem == null)
                return;
            
            if (!TryCollectItem(worldItem.Item))
                return;
            
            Destroy(col.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var worldItem = col.GetComponent<WorldItemView>();

            if (worldItem == null)
                return;
            
            if (!TryCollectItem(worldItem.Item))
                return;
            
            Destroy(col.gameObject);
        }

        private bool TryCollectItem(Item item)
        {
            if (_playerInventory.GetFreeSpacesCount() == 0
                || !_playerInventory.TryGetFirstFreeSpaceIndex(out var freeSpaceIndex))
                return false;

            _playerInventory.Items[freeSpaceIndex] = item;
            return true;
        }
    }
}
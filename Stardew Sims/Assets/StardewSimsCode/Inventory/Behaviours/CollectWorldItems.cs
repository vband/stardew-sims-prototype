using StardewSimsCode.Inventory.Items;
using StardewSimsCode.Inventory.Views;
using UnityEngine;

namespace StardewSimsCode.Inventory.Behaviours
{
    public class CollectWorldItems : MonoBehaviour
    {
        [SerializeField] private Inventory _playerInventory;

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

            _playerInventory.AddItem(freeSpaceIndex, item);
            return true;
        }
    }
}
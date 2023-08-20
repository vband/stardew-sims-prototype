using System.Collections.Generic;
using UnityEngine;

namespace StardewSimsCode.Inventory.Views
{
    public class InventoryItemsView : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private List<InterfaceItemView> _itemViews;

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
            for (var i = 0; i < _inventory.Items.Length; i++)
            {
                _itemViews[i].TrySetItem(_inventory.Items[i]);
                _itemViews[i].UpdateView();
            }
        }
    }
}
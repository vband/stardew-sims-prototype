using System.Collections.Generic;
using StardewSimsCode.Inventory.Views.UI.ItemSlotViews;
using UnityEngine;

namespace StardewSimsCode.Inventory.Views.UI.InventoryViews
{
    public class NpcInventoryView : MonoBehaviour
    {
        [SerializeField] private List<ItemSlotView> _itemSlotViews;

        public void SetUpInventoryView(object data)
        {
            if (data is not Inventory inventory)
                return;
            
            _itemSlotViews.ForEach(slotView => slotView.SetInventory(inventory));
        }
    }
}
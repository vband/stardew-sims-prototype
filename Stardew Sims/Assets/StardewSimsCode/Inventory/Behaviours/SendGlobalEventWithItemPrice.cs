using StardewSimsCode.GlobalEvents;
using StardewSimsCode.Inventory.Views.UI.ItemSlotViews;
using UnityEngine;

namespace StardewSimsCode.Inventory.Behaviours
{
    public class SendGlobalEventWithItemPrice : MonoBehaviour
    {
        [SerializeField] private ItemSlotView _itemSlotView;
        [SerializeField] private GlobalEvent _globalEvent;

        public void SendGlobalEvent()
        {
            if (!_itemSlotView.IsActive)
                return;
            
            var itemPrice = _itemSlotView.Item.Price.ToString();
            _globalEvent.Trigger(itemPrice);
        }
    }
}
using StardewSimsCode.GlobalEvents;
using UnityEngine;

namespace StardewSimsCode.NpcInteraction
{
    public class NpcInteraction : MonoBehaviour
    {
        [SerializeField] private GlobalEvent _openNpcInventoryViewGlobalEvent;
        [SerializeField] private GlobalEvent _closeNpcInventoryViewGlobalEvent;
        [SerializeField] private Inventory.Inventory _npcInventory;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            _openNpcInventoryViewGlobalEvent.Trigger(_npcInventory);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _closeNpcInventoryViewGlobalEvent.Trigger(null);
        }
    }
}
using UnityEngine;

namespace StardewSimsCode.Inventory
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "StardewSims/Inventory/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite _inventorySprite;
        [SerializeField] private Sprite _worldSprite;

        public Sprite InventorySprite => _inventorySprite;
        public Sprite WorldSprite => _worldSprite;
    }
}
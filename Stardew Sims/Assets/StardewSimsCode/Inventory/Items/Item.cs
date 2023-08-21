using UnityEngine;

namespace StardewSimsCode.Inventory.Items
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "StardewSims/Inventory/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite _inventorySprite;
        [SerializeField] private Sprite _worldSprite;
        [SerializeField] private Sprite _displaySprite;
        [SerializeField] private int _price;

        public Sprite InventorySprite => _inventorySprite;
        public Sprite WorldSprite => _worldSprite;
        public Sprite DisplaySprite => _displaySprite;
        public int Price => _price;
    }
}
using TMPro;
using UnityEngine;

namespace StardewSimsCode.Inventory.Views.UI
{
    public class CurrentGoldView : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private TextMeshProUGUI _text;

        public void SetInventory(object data)
        {
            if (data is not Inventory inventory)
                return;

            _inventory = inventory;
            UpdateView();
        }

        private void Start()
        {
            UpdateView();
        }

        private void OnEnable()
        {
            _inventory.InventoryChanged += UpdateView;
        }

        private void OnDisable()
        {
            _inventory.InventoryChanged -= UpdateView;
        }

        private void UpdateView()
        {
            _text.text = _inventory.Gold.ToString();
        }
    }
}
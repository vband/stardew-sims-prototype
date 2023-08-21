using TMPro;
using UnityEngine;

namespace StardewSimsCode.Inventory.Views.UI
{
    public class CurrentGoldView : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private TextMeshProUGUI _text;

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
using TMPro;
using UnityEngine;

namespace StardewSimsCode.Utils
{
    public class SetText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void UpdateText(object data)
        {
            if (data is not string text)
                return;

            _text.text = text;
        }
    }
}
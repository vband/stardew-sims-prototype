using UnityEngine;

namespace StardewSimsCode.Utils
{
    public class ToggleGameObject : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
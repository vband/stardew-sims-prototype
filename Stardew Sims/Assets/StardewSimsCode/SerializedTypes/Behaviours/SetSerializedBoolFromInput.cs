using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StardewSimsCode.SerializedTypes.Behaviours
{
    public class SetSerializedBoolFromInput : MonoBehaviour
    {
        [SerializeField] private SerializedBool _boolVariable;

        private void Start()
        {
            if (_boolVariable == null)
                Debug.LogError($"{_boolVariable.name} is null");
        }

        public void SetValue(InputAction.CallbackContext context)
        {
            if (_boolVariable == null)
                return;
            
            var inputValue = context.ReadValue<float>();
            _boolVariable.SetValue(inputValue != 0f);
        }
    }
}
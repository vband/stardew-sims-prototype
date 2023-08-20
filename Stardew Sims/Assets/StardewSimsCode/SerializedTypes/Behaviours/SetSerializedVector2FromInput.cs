using StardewSimsCode.SerializedTypes.Base;
using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StardewSimsCode.SerializedTypes.Behaviours
{
    public class SetSerializedVector2FromInput : SetSerializedVariableFromInputBehaviour
    {
        [SerializeField] private SerializedVector2 _vector2Variable;

        private void Start()
        {
            if (_vector2Variable == null)
                Debug.LogError($"{_vector2Variable.name} is null");
        }

        public override void SetValue(InputAction.CallbackContext context)
        {
            if (_vector2Variable == null)
                return;
            
            var inputValue = context.ReadValue<Vector2>();
            _vector2Variable.SetValue(inputValue);
        }
    }
}
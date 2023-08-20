using UnityEngine;
using UnityEngine.InputSystem;

namespace StardewSimsCode.SerializedTypes.Base
{
    public abstract class SetSerializedVariableFromInputBehaviour : MonoBehaviour
    {
        public abstract void SetValue(InputAction.CallbackContext context);
    }
}
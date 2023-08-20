using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;

namespace StardewSimsCode.PlayerInputBehaviours.Base
{
    public abstract class PlayerInputBehaviour : MonoBehaviour
    {
        [SerializeField] protected SerializedBool _runInput;
        [SerializeField] protected SerializedVector2 _movementInput;

        private void OnEnable()
        {
            _runInput.ValueChanged += OnInputValuesChanged;
            _movementInput.ValueChanged += OnInputValuesChanged;
        }

        private void OnDisable()
        {
            _runInput.ValueChanged -= OnInputValuesChanged;
            _movementInput.ValueChanged -= OnInputValuesChanged;
        }

        protected abstract void OnInputValuesChanged();
    }
}
using StardewSimsCode.PlayerInputBehaviours.Base;
using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;

namespace StardewSimsCode.PlayerInputBehaviours.Implementations
{
    public class CharacterMovementFromInput : PlayerInputBehaviour
    {
        [SerializeField] private SerializedFloat _walkVelocity;
        [SerializeField] private SerializedFloat _runVelocity;
        [SerializeField] private SerializedBool _movementEnabled;
        
        private void Start()
        {
            if (_movementInput == null)
                Debug.LogError($"{_movementInput.name} is null");
            
            if (_runInput == null)
                Debug.LogError($"{_runInput.name} is null");
            
            if (_walkVelocity == null)
                Debug.LogError($"{_walkVelocity.name} is null");
            
            if (_runVelocity == null)
                Debug.LogError($"{_runVelocity.name} is null");
            
            if (_movementEnabled == null)
                Debug.LogError($"{_movementEnabled.name} is null");
        }

        private void Update()
        {
            MoveCharacter();
        }

        private void MoveCharacter()
        {
            if (_movementInput == null
                || _runInput == null
                || _walkVelocity == null
                || _runVelocity == null
                || _movementEnabled == null
                || !_movementEnabled.Value)
                return;
            
            var translation = new Vector3(_movementInput.Value.x, _movementInput.Value.y, 0);
            var velocity = _runInput.Value ? _runVelocity.Value : _walkVelocity.Value;
            transform.Translate(translation * velocity * Time.deltaTime);
        }

        protected override void OnInputValuesChanged()
        {
            // Code smell :(
        }
    }
}

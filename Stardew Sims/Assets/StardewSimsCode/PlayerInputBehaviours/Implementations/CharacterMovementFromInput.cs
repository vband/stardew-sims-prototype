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
        
        private void Update()
        {
            MoveCharacter();
        }

        private void MoveCharacter()
        {
            if (!_movementEnabled.Value)
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

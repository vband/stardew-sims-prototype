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

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

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
            rb.velocity = translation * velocity;
        }

        protected override void OnInputValuesChanged()
        {
            // Code smell :(
        }
    }
}

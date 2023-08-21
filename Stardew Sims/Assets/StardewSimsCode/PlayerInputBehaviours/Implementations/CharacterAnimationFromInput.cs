using StardewSimsCode.PlayerInputBehaviours.Base;
using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;

namespace StardewSimsCode.PlayerInputBehaviours.Implementations
{
    public class CharacterAnimationFromInput : PlayerInputBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SerializedString _isWalkingParameterName;
        [SerializeField] private SerializedString _isRunningParameterName;
        [SerializeField] private SerializedString _horizontalMovementParameterName;
        [SerializeField] private SerializedString _verticalMovementParameterName;

        protected override void OnInputValuesChanged()
        {
            AnimateCharacter();
        }

        private void AnimateCharacter()
        {
            var isMovementMagnitudePositive = _movementInput.Value.magnitude > 0f;
            var running = _runInput.Value && isMovementMagnitudePositive;
            var walking = !_runInput.Value && isMovementMagnitudePositive;
            var verticalMovement = _movementInput.Value.y;

            // Avoid conflicting the vertical and horizontal movement animations
            var horizontalMovement = verticalMovement == 0f ? _movementInput.Value.x : 0f;

            _animator.SetBool(_isRunningParameterName.Value, running);
            _animator.SetBool(_isWalkingParameterName.Value, walking);
            _animator.SetFloat(_horizontalMovementParameterName.Value, horizontalMovement);
            _animator.SetFloat(_verticalMovementParameterName.Value, verticalMovement);
        }
    }
}
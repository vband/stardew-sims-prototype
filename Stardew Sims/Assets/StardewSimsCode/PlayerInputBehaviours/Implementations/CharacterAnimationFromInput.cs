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

        private void Start()
        {
            if (_movementInput == null)
                Debug.LogError($"{_movementInput.name} is null");
            
            if (_runInput == null)
                Debug.LogError($"{_runInput.name} is null");
            
            if (_animator == null)
                Debug.LogError($"{_animator.name} is null");
            
            if (_isWalkingParameterName == null)
                Debug.LogError($"{_isWalkingParameterName.name} is null");
            
            if (_isRunningParameterName == null)
                Debug.LogError($"{_isRunningParameterName.name} is null");
            
            if (_horizontalMovementParameterName == null)
                Debug.LogError($"{_horizontalMovementParameterName.name} is null");
            
            if (_verticalMovementParameterName == null)
                Debug.LogError($"{_verticalMovementParameterName.name} is null");
        }

        protected override void OnInputValuesChanged()
        {
            AnimateCharacter();
        }

        private void AnimateCharacter()
        {
            if (_movementInput == null
                || _runInput == null
                || _animator == null
                || _isWalkingParameterName == null
                || _isRunningParameterName == null
                || _horizontalMovementParameterName == null
                || _verticalMovementParameterName == null)
                return;

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
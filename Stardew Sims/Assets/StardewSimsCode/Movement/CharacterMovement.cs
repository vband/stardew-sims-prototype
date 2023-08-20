using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StardewSimsCode.Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private SerializedFloat _walkVelocity;
        [SerializeField] private SerializedFloat _runVelocity;
        [SerializeField] private SerializedBool _isRunning;
        [SerializeField] private SerializedBool _movementEnabled;

        private Vector2 _inputValue;
        
        public void GetInput(InputAction.CallbackContext context)
        {
            _inputValue = context.ReadValue<Vector2>();
        }

        private void Start()
        {
            if (_walkVelocity == null)
                Debug.LogError($"{_walkVelocity.name} is null");
            
            if (_runVelocity == null)
                Debug.LogError($"{_runVelocity.name} is null");
            
            if (_isRunning == null)
                Debug.LogError($"{_isRunning.name} is null");
            
            if (_movementEnabled == null)
                Debug.LogError($"{_movementEnabled.name} is null");
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_walkVelocity == null
                || _runVelocity == null
                || _isRunning == null
                || _movementEnabled == null
                || !_movementEnabled.Value)
                return;
            
            var translation = new Vector3(_inputValue.x, _inputValue.y, 0);
            var velocity = _isRunning.Value ? _runVelocity.Value : _walkVelocity.Value;
            transform.Translate(translation * velocity * Time.deltaTime);
        }
    }
}

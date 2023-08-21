using UnityEngine;
using UnityEngine.Events;

namespace StardewSimsCode.GlobalEvents
{
    public class GlobalEventListener : MonoBehaviour
    {
        [SerializeField] private GlobalEvent _globalEvent;
        [SerializeField] private UnityEvent<object> _onGlobalEventTriggered;

        private void OnEnable()
        {
            _globalEvent.OnTriggered += OnGlobalEventTriggered;
        }

        private void OnDisable()
        {
            _globalEvent.OnTriggered -= OnGlobalEventTriggered;
        }

        private void OnGlobalEventTriggered(object data)
        {
            _onGlobalEventTriggered.Invoke(data);
        }
    }
}
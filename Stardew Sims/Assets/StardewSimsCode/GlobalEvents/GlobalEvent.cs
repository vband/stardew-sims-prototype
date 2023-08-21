using UnityEngine;

namespace StardewSimsCode.GlobalEvents
{
    [CreateAssetMenu(fileName = "NewGlobalEvent", menuName = "StardewSims/GlobalEvents/GlobalEvent")]
    public class GlobalEvent : ScriptableObject
    {
        public delegate void OnGlobalEventTriggeredDelegate(object data);
        public event OnGlobalEventTriggeredDelegate OnTriggered;
        
        public void Trigger(object data)
        {
            OnTriggered?.Invoke(data);
        }
    }
}
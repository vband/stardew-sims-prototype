using StardewSimsCode.SerializedTypes.Base;
using UnityEngine;

namespace StardewSimsCode.SerializedTypes.Implementations
{
    [CreateAssetMenu(fileName = "NewSerializedBool", menuName = "StardewSims/SerializedTypes/Bool")]
    public class SerializedBool : SerializedType<bool>
    {
        public void SetInvertedValue(bool value)
        {
            _runtimeValue = !value;
        }
    }
}
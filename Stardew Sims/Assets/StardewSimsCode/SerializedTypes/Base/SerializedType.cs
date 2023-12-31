﻿using UnityEngine;

namespace StardewSimsCode.SerializedTypes.Base
{
    public abstract class SerializedType<T> : ScriptableObject
    {
        [SerializeField] protected T _initialValue;
        [SerializeField] protected T _runtimeValue;
        
        public T Value => _runtimeValue;

        public delegate void OnValueChangedDelegate();

        public event OnValueChangedDelegate ValueChanged;

        public void OnEnable()
        {
            _runtimeValue = _initialValue;
        }

        public void SetValue(T value)
        {
            _runtimeValue = value;
            
            ValueChanged?.Invoke();
        }
    }
}
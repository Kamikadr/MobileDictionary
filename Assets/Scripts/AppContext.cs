using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppContext : MonoBehaviour
{
    private List<IDisposable> _disposables;
    private Dictionary<Type, object> _registeredTypes;

    private void Awake()
    {
        _disposables = new List<IDisposable>();
        _registeredTypes = new Dictionary<Type, object>();


    }

    private void OnDestroy()
    {
        foreach(var disposable in _disposables) 
        {
            disposable.Dispose();
        }
    }
    public T Resolve<T>()
    {
        return (T) _registeredTypes[typeof(T)];
    }

    private void RegisterInstance<T>(T instance) 
    {
        if(instance is IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        _registeredTypes.Add(typeof(T), instance);
    }
}

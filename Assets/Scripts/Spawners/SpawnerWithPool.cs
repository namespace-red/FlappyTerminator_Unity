using System;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerWithPool<T> : MonoBehaviour
    where T : MonoBehaviour, IPoolableObject
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _prefabParent;

    private ObjectPool<T> _pool;
    
    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(OnCreateObject, OnGetObject, OnReleaseObject, OnDestroyObject);
    }

    protected virtual void OnValidate()
    {
        if (_prefab == null)
            throw new NullReferenceException(nameof(_prefab));
        
        if (_prefabParent == null)
            throw new NullReferenceException(nameof(_prefabParent));
    }

    public virtual T Spawn()
    {
        return _pool.Get();
    }

    public virtual void Release(T obj)
    {
        _pool.Release(obj);
    }

    protected virtual T OnCreateObject()
    {
        var obj = Instantiate(_prefab, _prefabParent);
        obj.gameObject.SetActive(false);

        obj.Released += OnObjectReleased;
        return obj;
    }

    protected virtual void OnGetObject(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void OnReleaseObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }
    
    protected virtual void OnDestroyObject(T obj)
    {
        obj.Released -= OnObjectReleased;
        Destroy(obj);
    }

    private void OnObjectReleased(IPoolableObject obj)
    {
        Release((T)obj);
    }
}

using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerByPointsWithPool<T> : SpawnerWithPool<T>
    where T : MonoBehaviour, IPoolableObject
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField, Min(0)] private float _coolDown;

    protected override void OnValidate()
    {
        base.OnValidate();
        
        if (_spawnPoints.Length == 0)
            throw new NullReferenceException(name +  " SpawnPoints is empty");
    }
    
    private void OnEnable()
    {
        StartCoroutine(Run());
    }

    protected override void OnGetObject(T obj)
    {
        SpawnPoint spawnPoint = GetSpawnPoint();
        spawnPoint.Occupy(obj);
        
        obj.transform.position = spawnPoint.Position;
        base.OnGetObject(obj);
    }

    private IEnumerator Run()
    {
        var wait = new WaitForSeconds(_coolDown);
        
        while (enabled)
        {
            if (HaveFreeSpawnPoint())
            {
                Spawn();
            }
            
            yield return wait;
        }
    }

    private bool HaveFreeSpawnPoint()
    {
        return _spawnPoints.Any(spawnPoint => spawnPoint.IsFree);
    }
    
    private SpawnPoint GetSpawnPoint()
    {
        int randomPoint;
        
        do
        {
            randomPoint = Random.Range(0, _spawnPoints.Length);
        } while (_spawnPoints[randomPoint].IsFree == false);

        return _spawnPoints[randomPoint];
    }
}

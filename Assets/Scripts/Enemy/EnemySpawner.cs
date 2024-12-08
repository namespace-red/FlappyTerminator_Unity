using System;
using UnityEngine;

public class EnemySpawner : SpawnerByPointsWithPool<Enemy>
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Vector2 _direction;

    private int _releasedCount;
    
    public event Action<int> Released;
    
    protected override void OnValidate()
    {
        base.OnValidate();
        
        if (_bulletSpawner == null)
            throw new NullReferenceException(nameof(_bulletSpawner));

        if (_direction == Vector2.zero)
            throw new ArgumentException(nameof(_direction));
    }
    
    public override void Release(Enemy obj)
    {
        Released?.Invoke(++_releasedCount);
        base.Release(obj);
    }

    protected override void OnGetObject(Enemy enemy)
    {
        enemy.transform.right = _direction;
        enemy.Init(_bulletSpawner);
        base.OnGetObject(enemy);
    }
}

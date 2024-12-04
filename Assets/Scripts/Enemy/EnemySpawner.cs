using System;
using UnityEngine;

public class EnemySpawner : SpawnerByPointsWithPool<Enemy>
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Vector2 _direction;

    protected override void OnValidate()
    {
        base.OnValidate();
        
        if (_bulletSpawner == null)
            throw new NullReferenceException(nameof(_bulletSpawner));

        if (_direction == Vector2.zero)
            throw new ArgumentException(nameof(_direction));
    }

    protected override void OnGetObject(Enemy enemy)
    {
        enemy.transform.right = _direction;
        enemy.Init(_bulletSpawner);
        base.OnGetObject(enemy);
    }
}

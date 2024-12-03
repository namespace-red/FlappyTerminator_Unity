using UnityEngine;

public class BulletSpawner : SpawnerWithPool<Bullet>
{
    private Vector3 _position;
    private Vector2 _direction;
    private LayerMask _layerMask;

    public Bullet Spawn(Vector3 position, Vector2 direction, LayerMask layerMask)
    {
        _position = position;
        _direction = direction;
        _layerMask = layerMask;
        return Spawn();
    }

    protected override void OnGetObject(Bullet bullet)
    {
        bullet.transform.position = _position;
        bullet.Init(_direction, _layerMask);
        base.OnGetObject(bullet);
    }
}

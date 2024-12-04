using System;
using UnityEngine;

[RequireComponent(typeof(BulletCollision))]
[RequireComponent(typeof(BulletMover))]
public class Bullet : MonoBehaviour, IPoolableObject
{
    private BulletCollision _collision;
    private BulletMover _mover;

    public event Action<IPoolableObject> Released;
    private void Awake()
    {
        _collision = GetComponent<BulletCollision>();
        _mover = GetComponent<BulletMover>();
    }

    private void OnEnable()
    {
        _collision.Collided += Release;
        _mover.Move();
    }

    private void OnDisable()
    {
        _collision.Collided -= Release;
        _mover.Stop();
    }

    private void Release()
    {
        Released?.Invoke(this);
    }
}

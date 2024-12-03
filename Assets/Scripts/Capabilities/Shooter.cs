using System;
using System.Timers;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private const int MsecInSec = 1000;
    
    [SerializeField, Min(0)] private float _coolDown;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private BulletSpawner _bulletSpawner;
    
    private Timer _timer = new Timer();

    public bool CanUse => _timer.Enabled == false;

    private void Awake()
    {
        _timer.AutoReset = false;
    }

    private void OnValidate()
    {
        if (_shootPoint == null)
            throw new NullReferenceException(nameof(_shootPoint));

        if (_direction == Vector2.zero)
            throw new ArgumentException(nameof(_direction));
        
        if (_bulletSpawner == null)
            throw new NullReferenceException(nameof(_bulletSpawner));
    }

    public void Attack()
    {
        _timer.Interval = _coolDown * MsecInSec;
        _timer.Start();
        _bulletSpawner.Spawn(_shootPoint.position, _direction, gameObject.layer);
    }
}

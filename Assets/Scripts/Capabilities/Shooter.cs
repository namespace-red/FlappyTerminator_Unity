using System;
using System.Timers;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private const int MsecInSec = 1000;
    
    [SerializeField, Min(0)] private float _coolDown;
    [SerializeField] private Transform _shootPoint;
    
    private BulletSpawner _bulletSpawner;
    private Timer _timer = new Timer();

    public bool CanUse => _timer.Enabled == false;
    public float CoolDown => _coolDown;

    private void Awake()
    {
        _timer.AutoReset = false;
    }

    private void OnValidate()
    {
        if (_shootPoint == null)
            throw new NullReferenceException(nameof(_shootPoint));
    }

    public void Init(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner ?? throw new NullReferenceException(nameof(bulletSpawner));
    }
    
    public void Shoot()
    {
        _timer.Interval = _coolDown * MsecInSec;
        _timer.Start();
        _bulletSpawner.Spawn(_shootPoint.position, transform.right, gameObject.layer);
    }
}

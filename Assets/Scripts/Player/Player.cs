using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : StarShip
{
    private const int LeftMouseButton = 0;
    
    [SerializeField] private BulletSpawner _bulletSpawner;
    
    private PlayerMover _mover;
    private bool _isMoving;
    private bool _isAttacking;

    protected override void Awake()
    {
        base.Awake();
        _mover = GetComponent<PlayerMover>();
        
        if (_bulletSpawner == null)
            throw new NullReferenceException(nameof(_bulletSpawner));
        
        Shooter.Init(_bulletSpawner);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isMoving = true;
        }

        if (Input.GetMouseButton(LeftMouseButton))
        {
            _isAttacking = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _mover.Move();
            _isMoving = false;
        }

        if (_isAttacking && Shooter.CanUse)
        {
            Shooter.Shoot();
        }

        _isAttacking = false;
    }
}

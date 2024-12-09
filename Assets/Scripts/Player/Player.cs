using System;
using UnityEngine;

[RequireComponent(typeof(UserInput))]
[RequireComponent(typeof(PlayerMover))]
public class Player : StarShip
{    
    [SerializeField] private BulletSpawner _bulletSpawner;

    private UserInput _userInput;
    private PlayerMover _mover;
    private bool _isMoving;

    protected override void Awake()
    {
        base.Awake();
        
        if (_bulletSpawner == null)
            throw new NullReferenceException(nameof(_bulletSpawner));
        
        _userInput = GetComponent<UserInput>();
        _mover = GetComponent<PlayerMover>();
        
        Shooter.Init(_bulletSpawner);
    }

    private void OnEnable()
    {
        _userInput.SpacePressed += OnMoveButtonPressed;
        _userInput.LeftMousePressed += OnShootButtonPressed;
    }


    private void OnDisable()
    {
        _userInput.SpacePressed -= OnMoveButtonPressed;
        _userInput.LeftMousePressed -= OnShootButtonPressed;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _mover.Move();
            _isMoving = false;
        }
    }
	
	private void OnMoveButtonPressed()
	{
		_isMoving = true;
	}
	
	private void OnShootButtonPressed()
	{
        if (Shooter.CanUse)
        {
            Shooter.Shoot();
        }
	}
}

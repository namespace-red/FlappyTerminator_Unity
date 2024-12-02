using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : StarShip
{
    private const int LeftMouseButton = 0;
    
    private PlayerMover _mover;
    private bool _isMoving;
    private bool _isAttacking;

    protected override void Awake()
    {
        base.Awake();
        _mover = GetComponent<PlayerMover>();
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
            Shooter.Attack();
        }

        _isAttacking = false;
    }
}

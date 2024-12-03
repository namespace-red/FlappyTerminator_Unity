using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isMoving;

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            transform.Translate(transform.right * (_speed * Time.fixedDeltaTime));
        }
    }

    public void Init(Vector2 direction)
    {
        transform.right = direction;
    }
    
    public void Move()
    {
        _isMoving = true;
    }

    public void Stop()
    {
        _isMoving = false;
    }
}

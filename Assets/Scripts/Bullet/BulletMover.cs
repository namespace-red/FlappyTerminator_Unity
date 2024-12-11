using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isMoving;

    private void Update()
    {
        if (_isMoving)
        {
            transform.position += transform.right * (_speed * Time.deltaTime);
        }
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

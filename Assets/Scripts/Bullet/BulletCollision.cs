using System;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class BulletCollision : MonoBehaviour
{
    private Attacker _attacker;

    public event Action Collided;
    
    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
        {
            _attacker.Attack(health);
            Collided?.Invoke();
        }
        else if (other.TryGetComponent(out Bullet bullet))
        {
            Collided?.Invoke();
        }
    }
}

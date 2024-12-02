using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField, Min(0)] private float _damage;

    public void Attack(Health _health)
    {
        _health.ApplyDamage(_damage);
    }
}

using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Health))]
public class StarShip : MonoBehaviour
{
    protected Shooter Shooter;
    
    private Health _health;

    public Health Health => _health;

    protected virtual void Awake()
    {
        Shooter = GetComponent<Shooter>();
        _health = GetComponent<Health>();
    }
}

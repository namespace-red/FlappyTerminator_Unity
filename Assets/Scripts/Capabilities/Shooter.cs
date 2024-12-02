using System;
using System.Timers;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField, Min(0)] private float _coolDown;
    [SerializeField] private Transform _shootPoint;
    
    private Timer _timer = new Timer();

    public bool CanUse => _timer.Enabled == false;

    private void OnValidate()
    {
        if (_shootPoint == null)
            throw new NullReferenceException(nameof(_shootPoint));
    }

    public void Attack()
    {
        _timer.Interval = _coolDown;
        _timer.Start();
        Debug.Log("Shoot");
    }
}

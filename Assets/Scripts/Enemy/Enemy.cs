using System;
using System.Collections;
using UnityEngine;

public class Enemy : StarShip, IPoolableObject
{
    public event Action<IPoolableObject> Released;
    
    private void OnEnable()
    {
        Health.Died += Die;
        StartCoroutine(RunAttack());
    }

    private void OnDisable()
    {
        Health.Died -= Die;
    }

    public void Init(BulletSpawner bulletSpawner)
    {
        Health.HealFull();
        Shooter.Init(bulletSpawner);
    }
    
    private void Die()
    {
        Released?.Invoke(this);
    }

    private IEnumerator RunAttack()
    {
        var wait = new WaitForSeconds(Shooter.CoolDown);

        while (enabled)
        {
            yield return wait;

            if (Shooter.CanUse)
            {
                Shooter.Shoot();
            }
        }
    }
}

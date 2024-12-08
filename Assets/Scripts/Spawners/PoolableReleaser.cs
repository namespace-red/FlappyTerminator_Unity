using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PoolableReleaser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IPoolableObject poolableObject))
        {
            poolableObject.Release();
        }
    }
}

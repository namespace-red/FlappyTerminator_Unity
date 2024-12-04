using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3 Position => transform.position;
    public bool IsFree => Owner == null;
    public IPoolableObject Owner { get; private set; }

    public void Occupy(IPoolableObject owner)
    {
        Owner = owner;
        Owner.Released += Release;
    }

    private void Release(IPoolableObject obj)
    {
        Owner.Released -= Release;
        Owner = null;
    }
}

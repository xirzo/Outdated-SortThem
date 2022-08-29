using System;
using UnityEngine;
using UnityEngine.Networking.Types;

public class BugHealth : MonoBehaviour
{
    public event Action OnDied;
    public void Die()
    {
        OnDied?.Invoke();
        Destroy(gameObject);
    }
}

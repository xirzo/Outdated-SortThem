using System;
using UnityEngine;

public class BugHealth : MonoBehaviour
{
    public event Action OnDied;
    [SerializeField] private AudioClip _deathSound;
    public void Die()
    {
        AudioSource.PlayClipAtPoint(_deathSound, transform.position);
        OnDied?.Invoke();
        Destroy(gameObject);
    }
}

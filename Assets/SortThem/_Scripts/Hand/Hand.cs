using UnityEngine;

[RequireComponent(typeof(HandAttack))]
public class Hand : MonoBehaviour
{
    public static Hand Instance { get; private set; }

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
}

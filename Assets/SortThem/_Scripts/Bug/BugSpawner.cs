using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bugPrefab;
    [SerializeField] private bool _spawn;


    private void OnEnable()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (_spawn)
        {
            var newBug = Instantiate(_bugPrefab, transform.position, Quaternion.identity);
        }
    }
}

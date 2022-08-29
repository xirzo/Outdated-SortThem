using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovementStats : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    public float MovementSpeed => _movementSpeed;
}

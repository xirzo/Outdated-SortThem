using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttackStats : MonoBehaviour
{
    [SerializeField] private float _damage;

    public float Damage => _damage;
}

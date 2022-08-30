using System;
using UnityEngine;

[RequireComponent(typeof(Inputs))]
public class HandAttack : MonoBehaviour
{

    public event Action<Vector2> OnAttack;

    [SerializeField] private AttackStats _stats;
    [SerializeField] private LayerMask _bugLayer;
    [SerializeField] private CinemachineShake _cameraShake;
    [SerializeField] private AudioClip _attackSound;

    private Inputs _input;

    private RaycastHit2D[] _hits = new RaycastHit2D[5];

    private void OnEnable()
    {

        TryGetComponent(out _input);

        _input.OnAttackInput += Attack;
    }

    private void OnDisable()
    {
        _input.OnAttackInput -= Attack;
    }
    private void Attack()
    {
        GetTargets();
        ApplyDamage();

        _cameraShake.ShakeCamera();
        AudioSource.PlayClipAtPoint(_attackSound, transform.position);
        OnAttack?.Invoke(transform.position);
    }

    private void GetTargets()
    {
        _hits = Physics2D.CircleCastAll(transform.position, _stats.Radius, Vector2.zero, _stats.Radius, _bugLayer);
    }

    private void ApplyDamage()
    {
        foreach(var hit in _hits)
        {
            hit.collider.gameObject.TryGetComponent(out BugHealth targetHealth);
            targetHealth.Die();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _stats.Radius);
    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BugMovement : MonoBehaviour
{
    [SerializeField] private MovementStats _stats;
    [SerializeField] private float _attackAlertDistance;

    private Rigidbody2D _rigidbody;
    private HandAttack _handAttack;

    private float _movementSpeed;
    private float _movementSpeedMultiplier;

    private Vector2 _movementDirection;

    private bool _isMovingFaster;

    private void OnEnable()
    {
        Hand.Instance.gameObject.TryGetComponent(out _handAttack);
        TryGetComponent(out _rigidbody);

        _movementSpeed = _stats.MovementSpeed;
        _movementSpeedMultiplier = _stats.MovementSpeedMultiplier;

        ChangeDirection();

        _handAttack.OnAttack += ChangeDirectionFromAttack;
    }
    private void OnDisable()
    {
        _handAttack.OnAttack -= ChangeDirectionFromAttack;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _rigidbody.velocity = _movementDirection * _movementSpeed;
    }
    private void ChangeDirectionFromAttack(Vector2 attackPosition)
    {
        if (Vector3.Distance(transform.position, (Vector3)attackPosition) <= _attackAlertDistance)
        {
            if (!_isMovingFaster)
            {
                _isMovingFaster = true;
                StartCoroutine(ChangeSpeed());
            }
        }
    }
    private void ChangeDirection()
    {
        _movementDirection = new Vector2(Random.value, Random.value);
    }
    private void ChangeDirection(Vector3 objectNormal)
    {
        _movementDirection = Vector2.Reflect(_movementDirection, objectNormal);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirection(collision.contacts[0].normal);
    }

    private IEnumerator ChangeSpeed()
    {
        _movementSpeed *= _movementSpeedMultiplier;
        yield return new WaitForSeconds(_stats.FastMovingTime);
        _movementSpeed = _stats.MovementSpeed;
        _isMovingFaster = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackAlertDistance);
    }
}

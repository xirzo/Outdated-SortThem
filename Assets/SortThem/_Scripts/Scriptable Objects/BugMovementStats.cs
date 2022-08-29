using UnityEngine;

[CreateAssetMenu(menuName = "Data/Movement/DefaultBugMovement")]
public class BugMovementStats : MovementStats
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _movementSpeedMultiplier;
    [SerializeField] private float _fastMovingTime;

    public override float MovementSpeed => _movementSpeed;
    public override float MovementSpeedMultiplier => _movementSpeedMultiplier;
    public override float FastMovingTime => _fastMovingTime;
}

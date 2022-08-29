using UnityEngine;

public abstract class MovementStats : ScriptableObject
{
    public abstract float MovementSpeed { get; }
    public abstract float MovementSpeedMultiplier { get; }
    public abstract float FastMovingTime { get; }
}

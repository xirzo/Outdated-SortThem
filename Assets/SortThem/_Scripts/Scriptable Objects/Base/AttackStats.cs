using UnityEngine;

public abstract class AttackStats : ScriptableObject
{
    public abstract float Damage { get; }
    public abstract float Radius { get; }
}

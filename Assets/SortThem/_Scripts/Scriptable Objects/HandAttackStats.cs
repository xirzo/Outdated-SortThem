using UnityEngine;

[CreateAssetMenu(menuName = "Data/Attack/HandDefaultAttack")]
public class HandAttackStats : AttackStats
{
    [SerializeField] private float _damage;
    [SerializeField] private float _radius;

    public override float Damage => _damage;

    public override float Radius => _radius;
}

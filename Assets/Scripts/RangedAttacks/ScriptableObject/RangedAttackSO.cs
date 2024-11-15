using UnityEngine;

[CreateAssetMenu(fileName ="New Ranged Attack", menuName = "New Ranged Attack")]
public class RangedAttackSO : ScriptableObject
{
    [Header("Object Pooling")]
    public int initialSize = 10;
    public int maximumSize = 100;

    [Header("Spec")]
    public float shootRate = 0.5f;
    public int damagePerProjectile = 5;
    public float lifeOfProjectile = 5f;
    public float speed = 5f;
}
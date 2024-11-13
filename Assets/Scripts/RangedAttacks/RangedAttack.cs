using UnityEngine;
using UnityEngine.Pool;


public class RangedAttack : MonoBehaviour, IShootable
{
    // 공격 관련 데이터
    public RangedAttackSO data;
    public ObjectPool<Projectile> pool => ObjectPoolManager.Instance.pool;

    public Transform equipParent;
    public Vector3 firePoint => equipParent.position + equipParent.forward * 0.3f;


    void Awake()
    {
        equipParent = CharacterManager.Instance.Player.equip.equipParent;
    }

  
    
    // 세부 구현은 자식에서
    public virtual void Shoot()
    {
    }
}
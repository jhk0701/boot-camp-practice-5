using UnityEngine;
using UnityEngine.Pool;


public class RangedAttack : MonoBehaviour, IShootable
{
    // 공격 관련 데이터
    public RangedAttackSO data;
    
    // 오브젝트 풀링
    // TODO : 매니저 단으로 올릴 것
    public ObjectPool<Projectile> pool;

    public Transform equipParent;
    public Vector3 firePoint => equipParent.position + equipParent.forward * 0.3f;


    void Awake()
    {
        pool = new ObjectPool<Projectile>(Create, OnTake, OnReturned, OnDestroyed, false, data.initialSize, data.maximumSize);
        equipParent = CharacterManager.Instance.Player.equip.equipParent;
    }

    Projectile Create()
    {
        Projectile instance = Instantiate(data.projectile, transform); 
        
        instance.Initialize(this, data.lifeOfProjectile, data.damagePerProjectile);
        instance.gameObject.SetActive(false);

        return instance;
    }

    void OnTake(Projectile instance)
    {
        instance.gameObject.SetActive(true);
        instance.transform.SetParent(null);
    }

    void OnReturned(Projectile instance)
    {
        instance.transform.SetParent(transform);
        instance.gameObject.SetActive(false);
    }

    void OnDestroyed(Projectile instance)
    {
        Destroy(instance);
    }

    
    // 세부 구현은 자식에서
    public virtual void Shoot()
    {
        
    }
}
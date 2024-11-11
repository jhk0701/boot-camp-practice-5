using UnityEngine;
using UnityEngine.Pool;


public class RangedAttack : MonoBehaviour, IShootable
{
    // 오브젝트 풀링
    public ObjectPool<Projectile> pool;
    // 공격 관련 데이터
    public RangedAttackSO data;

    void Awake()
    {
        pool = new ObjectPool<Projectile>(Create, OnTake, OnReturned, OnDestroyed, false, data.initialSize, data.maximumSize);
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
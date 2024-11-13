using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    // 오브젝트 풀링
    public ObjectPool<Projectile> pool;
    public Projectile prefab;
    public int initialSize = 100;
    public int maximumSize = 300;

    private void Awake()
    {
        pool = new ObjectPool<Projectile>(Create, OnTake, OnReturned, OnDestroyed, false, initialSize, maximumSize);
    }

    Projectile Create()
    {
        Projectile instance = Instantiate(prefab, transform);
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

}

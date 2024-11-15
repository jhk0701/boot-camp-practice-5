using UnityEngine;

public class Projectile : MonoBehaviour
{
    float lifeTime = 5f;
    float damage = 5f;
    public Rigidbody Rigidbody { get; private set;}
    
    
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        Rigidbody.velocity = Vector3.zero;

        if (IsInvoking("Return"))
            CancelInvoke("Return");

        Invoke("Return", lifeTime);
    }

    public void Initialize(float life, float damage)
    {
        lifeTime = life;
        this.damage = damage;
    }
    
    public void Fire(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        Rigidbody.AddForce(direction, ForceMode.Impulse);
    }

    public void Return()
    {
        ObjectPoolManager.Instance.pool.Release(this);
    }
}

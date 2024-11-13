using UnityEngine;

public class Projectile : MonoBehaviour
{
    RangedAttack parent;
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

    public void Initialize(RangedAttack rangedAttack, float life, float damage)
    {
        parent = rangedAttack;
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
        if(parent == null)
        {
            Destroy(gameObject);
            return;
        }

        parent.pool.Release(this);
    }
}

using UnityEngine;

public class Projectile : MonoBehaviour
{
    RangedAttack parent;
    float lifeTime = 5f;
    float damage = 5f;
    Rigidbody _rigidbody;
    
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        _rigidbody.velocity = Vector3.zero;

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
        _rigidbody.AddForce(direction, ForceMode.Impulse);
    }

    public void Return()
    {
        parent.pool.Release(this);
    }
}

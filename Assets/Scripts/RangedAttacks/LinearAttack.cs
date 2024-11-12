using UnityEngine;

public class LinearAttack : RangedAttack
{
    public override void Shoot()
    {
        base.Shoot();
        // Debug.Log("LinearAttack");

        Projectile p = pool.Get();
        p.Rigidbody.useGravity = false;

        p.Fire(firePoint, -equipParent.right * data.speed);
    }

}
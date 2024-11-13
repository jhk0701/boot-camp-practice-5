using UnityEngine;

public class LinearAttack : RangedAttack
{
    public override void Shoot()
    {
        base.Shoot();
        // Debug.Log("LinearAttack");

        Projectile projectile = pool.Get();
        projectile.Initialize(data.lifeOfProjectile, data.damagePerProjectile);
        projectile.Rigidbody.useGravity = false;

        projectile.Fire(firePoint, -equipParent.right * data.speed);
    }

}
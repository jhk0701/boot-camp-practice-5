using UnityEngine;

public class ArcAttack : RangedAttack
{
    public override void Shoot()
    {
        base.Shoot();

        Projectile projectile = pool.Get();

        projectile.Initialize(data.lifeOfProjectile, data.damagePerProjectile);
        projectile.Rigidbody.useGravity = true;

        projectile.Fire(firePoint, -equipParent.right * data.speed);
    }
}
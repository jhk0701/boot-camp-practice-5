using UnityEngine;

public class CircularAttack : RangedAttack
{
    [SerializeField] int countOfProjectile = 6;

    public override void Shoot()
    {

        // 원형
        // 중심 - 플레이어
        // 플레이어 주변으로 퍼져 나가게

        // 시작 위치 : equipParent.position
        // 시작 방향 : 캐릭터의 정면
        // 회전 Q * V
        base.Shoot();
        float rotateAmount = 360f / countOfProjectile;
        for (int i = 0; i < countOfProjectile; i++)
        {
            Projectile projectile = pool.Get();

            Vector3 dir = Quaternion.Euler(0f, rotateAmount * i, 0f) * equipParent.forward;
            projectile.Rigidbody.useGravity = false;

            projectile.Fire(firePoint, dir * data.speed);
        }
    }

}
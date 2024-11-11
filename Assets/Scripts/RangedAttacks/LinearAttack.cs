using UnityEngine;

public class LinearAttack : RangedAttack
{
    public override void Shoot()
    {
        base.Shoot();
        // Debug.Log("LinearAttack");

        Projectile p = pool.Get();
        // 캐릭터 정면으로
        Transform playerTransform = CharacterManager.Instance.Player.transform;

        Vector3 firePoint = playerTransform.position + playerTransform.forward * 0.3f + playerTransform.up;
        Vector3 dir = playerTransform.forward * data.speed;

        p.Fire(firePoint, dir);
    }

}
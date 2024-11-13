using UnityEngine;

public class EquipRangedWeapon : EquipWeapon
{
    IShootable shootable;

    protected override void Awake()
    {
        base.Awake();
        if (TryGetComponent(out IShootable shootable))
        {
            this.shootable = shootable;
        }
    }

    public override void OnHit()
    {
        // 각종 원거리 공격 구현
        shootable.Shoot();
    }

}
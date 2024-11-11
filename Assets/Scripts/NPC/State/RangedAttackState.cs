using System;

public class RangedAttackState : AttackState
{
    public RangedAttackState(Enemy e) : base(e)
    { 
    }

    

    protected override void Attack()
    {
        // Projectile p = Instantiate(enemy.pro, transform.position + Vector3.up + transform.forward * 0.5f, Quaternion.identity);
        
        // p.Fire(transform.forward);
    }

}
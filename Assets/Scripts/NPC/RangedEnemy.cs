using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject projectile;

    protected override void SetState()
    {
        stateMap.Add(StateType.Idle, new IdleState(this));
        stateMap.Add(StateType.Wander, new WanderState(this));
        stateMap.Add(StateType.Attack, new RangedAttackState(this));
    }

}
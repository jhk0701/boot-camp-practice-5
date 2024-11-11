using UnityEngine;
using UnityEngine.AI;

public class AttackState : IState
{
    public Enemy enemy;
    public AttackState(Enemy e)
    { 
        enemy = e;
    }

    public virtual void Enter()
    {
        enemy.Agent.speed = enemy.runSpeed;
        enemy.Agent.isStopped = false;

        enemy.Animation.SetSpeed(enemy.Agent.speed / enemy.walkSpeed);
    }

    public virtual void Execute()
    {
        if (enemy.PlayerDistance < enemy.attackDistance && enemy.IsPlayerInFOV())
        {
            Attack();
        }
        else
        {
            if (enemy.PlayerDistance < enemy.detectDistance)
            {
                Track();
            }
            else
            {
                GiveUp();
            }
        }
    }

    protected virtual void Attack()
    {
        enemy.Agent.isStopped = true;
        if (Time.time - enemy.lastAttackTime > enemy.attackRate)
        {
            enemy.lastAttackTime = Time.time;
            CharacterManager.Instance.Player.GetComponent<IDamagable>().TakeDamage(enemy.damage);
            
            enemy.Animation.SetSpeed(1);
            enemy.Animation.SetAttack();
        }
    }

    protected virtual void Track()
    {
        enemy.Agent.isStopped = false;
        NavMeshPath path = new NavMeshPath();

        if (enemy.Agent.CalculatePath(CharacterManager.Instance.Player.transform.position, path))
        {
            enemy.Agent.SetDestination(CharacterManager.Instance.Player.transform.position);
        }
        else
        {
            enemy.Agent.SetDestination(enemy.transform.position);
            enemy.Agent.isStopped = true;
            enemy.StateMachine.SetState(enemy.stateMap[StateType.Wander]);
        }
    }

    void GiveUp()
    {
        enemy.Agent.SetDestination(enemy.transform.position);
        enemy.Agent.isStopped = true;
        enemy.StateMachine.SetState(enemy.stateMap[StateType.Wander]);
    }
}
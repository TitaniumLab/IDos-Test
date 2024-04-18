using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(Enemy enemy, StateMachine machine) : base(enemy, machine) { }

    public override void Enter()
    {
        Debug.Log("ChaseState");
    }
    public override void LogicUpdate()
    {
        if (_enemy.CurrentTargetTransform is null)
            _stateMachine.ChangetState(_enemy.EnemyPatrolState);
        if (_enemy.IsAttacking)
            _stateMachine.ChangetState(_enemy.EnemyAttackState);
    }

    public override void BehaviorUpdate()
    {
        Vector3 direction = _enemy.CurrentTargetTransform.position - _enemy.transform.position;
        _enemy.Rotate(direction);
        _enemy.Move();
    }
}

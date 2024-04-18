using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(Enemy enemy, StateMachine machine) : base(enemy, machine) { }


    public override void Enter()
    {
        Debug.Log("AttckState");
    }
    public override void LogicUpdate()
    {
        //if (_enemy.CurrentTargetTransform is null)
        //    _stateMachine.ChangetState(_enemy.EnemyPatrolState);
        if (!_enemy.IsAttacking)
            _stateMachine.ChangetState(_enemy.EnemyChaseState);
    }

    public override void BehaviorUpdate()
    {
        Vector3 direction = _enemy.CurrentTargetTransform.position - _enemy.transform.position;
        _enemy.Rotate(direction);
        _enemy.Fire();
    }
}

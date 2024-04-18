using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolState : State
{
    private float _idolEndTime;

    public IdolState(Enemy enemy, StateMachine machine) : base(enemy, machine) { }


    public override void Enter()
    {
        Debug.Log("IdolState");
        _idolEndTime = Time.time + _enemy.IdolTime;
    }

    public override void LogicUpdate()
    {
        if (Time.time > _idolEndTime)
            _stateMachine.ChangetState(_enemy.EnemyPatrolState);

        if (_enemy.CurrentTargetTransform is not null)
            _stateMachine.ChangetState(_enemy.EnemyChaseState);
    }
}

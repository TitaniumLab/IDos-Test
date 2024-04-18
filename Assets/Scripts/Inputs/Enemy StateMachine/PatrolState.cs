using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    private float _distanceToPoint = 0.1f;
    public PatrolState(Enemy enemy, StateMachine machine) : base(enemy, machine) { }

    public override void Enter()
    {
        Debug.Log("PatrolState");
    }
    public override void LogicUpdate()
    {
        float distance = (_enemy.RoutePoints[_enemy.CurrentPointIndex].position - _enemy.transform.position).magnitude;
        if (distance < _distanceToPoint)
            _stateMachine.ChangetState(_enemy.EnemyIdolState);
        if (_enemy.CurrentTargetTransform is not null)
            _stateMachine.ChangetState(_enemy.EnemyChaseState);
    }

    public override void BehaviorUpdate()
    {
        Vector3 direction = _enemy.RoutePoints[_enemy.CurrentPointIndex].position - _enemy.transform.position;
        Debug.Log(direction);
        _enemy.Rotate(direction);
        _enemy.Move();
    }
}

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

        if (_enemy.AgroPos != Vector3.zero)
        {
            float agroDistance = (_enemy.AgroPos - _enemy.transform.position).magnitude;
            Vector3 direction = _enemy.AgroPos - _enemy.transform.position;
            _enemy.Rotate(direction);
            _enemy.Move();
            if (agroDistance < _distanceToPoint)
                _enemy.Agro(Vector3.zero);
        }
        else
        {
            Vector3 direction = _enemy.RoutePoints[_enemy.CurrentPointIndex].position - _enemy.transform.position;
            _enemy.Rotate(direction);
            _enemy.Move();
        }
    }
}

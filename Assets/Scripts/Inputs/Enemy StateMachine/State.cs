public class State
{
    protected Enemy _enemy;
    protected StateMachine _stateMachine;

    protected State(Enemy enemy, StateMachine machine)
    {
        _enemy = enemy;
        _stateMachine = machine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void LogicUpdate() { }
    public virtual void BehaviorUpdate() { }
}

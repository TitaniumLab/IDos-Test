using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; }

    public void Initialize(State state)
    {
        CurrentState = state;
        CurrentState.Enter();
    }

    public void ChangetState(State state)
    {
        CurrentState.Exit();
        Initialize(state);
    }
}

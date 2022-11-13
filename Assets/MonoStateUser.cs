using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoState;

public class MonoStateUser : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Float,
    }

    MonoStateMachine<MonoStateUser> _stateMachine;

    void Start()
    {
        _stateMachine = new MonoStateMachine<MonoStateUser>(this);

        _stateMachine
            .AddState(State.Idle, null)
            .AddState(State.Move, null)
            .AddState(State.Float, null);

        _stateMachine.IsRun = true;
    }
}

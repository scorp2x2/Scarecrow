using ModestTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyStateManager : ITickable
{
    IEnemyState _currentStateHandler;
    EnemyStates _currentState = EnemyStates.None;

    List<IEnemyState> _states;

    public IEnemyState CurrentStateHandler { get => _currentStateHandler; }

    [Inject]
    public void Construct(EnemyStateIdle idle, EnemyStateBurning burning, EnemyStateWetness wetness)
    {
        _states = new List<IEnemyState> { idle, burning, wetness };
        ChangeState(EnemyStates.Idle);
    }

    public void ChangeState(EnemyStates state)
    {
        if (_currentState == state)
        {
            return;
        }

        _currentState = state;

        if (_currentStateHandler != null)
        {
            _currentStateHandler.ExitState();
            _currentStateHandler = null;
        }

        _currentStateHandler = _states[(int)state];
        _currentStateHandler.EnterState();
    }

    public void Tick()
    {
        _currentStateHandler.Update();
    }

    public enum EnemyStates
    {
        Idle,
        Burning,
        Wetness,
        None
    }
}

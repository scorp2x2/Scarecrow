using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyStateWetness : IEnemyState
{
    Settings _settings;
    EnemyStateManager _stateManager;
    Enemy _enemy;

    public float CountWetness { get; private set; }
    public float MaxCountWetness { get => _settings.MaxCountWetness; }

    public EnemyStateWetness(Settings settings, EnemyStateManager stateManager, Enemy enemy, SignalBus signalBus)
    {
        _settings = settings;
        _stateManager = stateManager;
        _enemy = enemy;

        signalBus.Subscribe<InputStateSignalButtonR>(OnClickButtonR);
    }

    void OnClickButtonR()
    {
        CountWetness = 0;
    }

    public void EnterState()
    {
        StartWetness();
    }

    public void ExitState()
    {
    }

    public void TakeDamage(Bullet bullet)
    {
        if (bullet is WaterBullet waterBullet)
        {
            AddWetness(waterBullet.CountWetness);
        }
        else if (bullet is FireBullet fireBullet)
        {
            CountWetness -= _settings.ReduceWetness;
            if (CountWetness < 0)
                _stateManager.ChangeState(EnemyStateManager.EnemyStates.Burning);
        }
        else if (bullet is GunBullet gunBullet)
        {
            _enemy.TakeDamage(gunBullet.Damage - _settings.ReduceDamage);
        }
    }

    void AddWetness(float count)
    {
        CountWetness += count;
        if (CountWetness > _settings.MaxCountWetness)
            CountWetness = _settings.MaxCountWetness;
    }

    void StartWetness()
    {
        CountWetness = 10;
    }

    public void Update()
    {
    }

    [Serializable]
    public class Settings
    {
        public float ReduceDamage;
        public float ReduceWetness;
        public float MaxCountWetness;
    }
}

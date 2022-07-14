using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBurning : IEnemyState
{
    Settings _settings;
    EnemyStateManager _stateManager;
    Enemy _enemy;

    float _startTimeBurning;
    float _durationBurning;
    bool _isBurning;

    public EnemyStateBurning(Settings settings, EnemyStateManager stateManager, Enemy enemy)
    {
        _settings = settings;
        _stateManager = stateManager;
        _enemy = enemy;
    }

    public void EnterState()
    {
        StartBurning();
    }

    public void ExitState()
    {
        _isBurning = false;
    }

    public void TakeDamage(Bullet bullet)
    {
        if (bullet is WaterBullet waterBullet)
        {
            _stateManager.ChangeState(EnemyStateManager.EnemyStates.Wetness);
        }
        else if (bullet is FireBullet fireBullet)
        {

            StartBurning();
            _enemy.TakeDamage(fireBullet.Damage);
        }
        else if (bullet is GunBullet gunBullet)
        {
            _enemy.TakeDamage(gunBullet.Damage + _settings.BonusDamage);
        }
    }

    void StartBurning()
    {
        _startTimeBurning = Time.time;
        _durationBurning = _settings.DelayBurning;
        _isBurning = true;
    }

    void IEnemyState.Update()
    {
        if (!_isBurning) return;
        if (_startTimeBurning + _durationBurning < Time.time)
        {
            _enemy.TakeDamage(_settings.DamageBurning);
            _durationBurning += _settings.DelayBurning;
        }

        if (_durationBurning > _settings.DurationBurning)
            _stateManager.ChangeState(EnemyStateManager.EnemyStates.Idle);
    }

    [Serializable]
    public class Settings
    {
        public float BonusDamage;
        public float DelayBurning;
        public float DamageBurning;
        public float DurationBurning;
    }
}

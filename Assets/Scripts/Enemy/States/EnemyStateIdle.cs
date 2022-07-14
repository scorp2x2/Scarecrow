using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateIdle : IEnemyState
{
    EnemyStateManager _stateManager;
    Enemy _enemy;

    public EnemyStateIdle(EnemyStateManager stateManager, Enemy enemy)
    {
        _stateManager = stateManager;
        _enemy = enemy;
    }

    public void TakeDamage(Bullet bullet)
    {
        if (bullet is WaterBullet waterBullet)
        {
            _stateManager.ChangeState(EnemyStateManager.EnemyStates.Wetness);
        }
        else if (bullet is FireBullet fireBullet)
        {
            _stateManager.ChangeState(EnemyStateManager.EnemyStates.Burning);
        }
        else if (bullet is GunBullet gunBullet)
        {
            _enemy.TakeDamage(gunBullet.Damage);
        }
    }

    public void EnterState()
    {
    }

    public void ExitState()
    {
    }

    public void Update()
    {
    }
}

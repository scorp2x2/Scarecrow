using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy
{
    SignalBus _signalBus;
    Settings _settings;

    public float HP { get; private set; }
    public float MaxHp { get => _settings.HP; }

    public bool IsDead { get; private set; }

    [Inject]
    public void Construct(SignalBus signalBus, Settings settings)
    {
        _signalBus = signalBus;
        _settings = settings;

        HP = settings.HP;
        signalBus.Subscribe<InputStateSignalButtonR>(OnPressR);
    }

    void OnPressR()
    {
        HP = _settings.HP;
        IsDead = false;
    }

    public void TakeDamage(float damage)
    {
        if (IsDead) return;

        HP -= damage;
        if (HP <= 0)
        {
            IsDead = true;
            _signalBus.Fire<EnemyDiedSignal>();
        }
    }

    [Serializable]
    public class Settings
    {
        public float HP;
    }
}

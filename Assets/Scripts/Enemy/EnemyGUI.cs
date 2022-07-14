using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyGUI : MonoBehaviour
{
    public Image imageHpBar;
    public Image imageWetnessBar;

    Enemy _enemy;
    EnemyStateManager _stateManager;

    [Inject]
    public void Construct(Enemy enemy, SignalBus signalBus, EnemyStateManager enemyStateManager)
    {
        _enemy = enemy;
        _stateManager = enemyStateManager;

        signalBus.Subscribe<EnemyDiedSignal>(OnEnemyDead);
        signalBus.Subscribe<InputStateSignalButtonR>(OnClickButtonR);
    }

    void OnEnemyDead()
    {
        gameObject.SetActive(false);
    }

    void OnClickButtonR()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        imageHpBar.fillAmount = _enemy.HP / _enemy.MaxHp;
        if (_stateManager.CurrentStateHandler is EnemyStateWetness wetness)
        {
            if (wetness.CountWetness > 0)
            {
                imageWetnessBar.gameObject.SetActive(true);
                imageWetnessBar.fillAmount = wetness.CountWetness / wetness.MaxCountWetness;
            }
            else
                imageWetnessBar.gameObject.SetActive(false);
        }
        else
            imageWetnessBar.gameObject.SetActive(false);
    }

    public void TakeDamage(Bullet bullet)
    {
        _stateManager.CurrentStateHandler.TakeDamage(bullet);
    }
}

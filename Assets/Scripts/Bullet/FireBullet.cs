using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FireBullet : Bullet
{
    public float Damage { get => settings.Damage; }

    [Inject]
    public void Construct(Settings settings)
    {
        base.settings = settings;
    }

    public override void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        var enemy = other.GetComponentInParent<EnemyGUI>();

        if (enemy != null)
            enemy.TakeDamage(this);
    }

    [Serializable]
    public new class Settings : Bullet.Settings
    {

    }
}

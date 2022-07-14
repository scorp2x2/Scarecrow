using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FireBall : Weapon, IPoolable<Vector3, IMemoryPool>
{
    public List<ParticleSystem> particleSystems;

    float _timeStart;
    float _minimumLifeTime;

    [Inject]
    public void Construct(FireBall.Settings settings)
    {
        base.settings = settings;
        _minimumLifeTime = settings.MinimumLifeTime;
    }

    public void OnDespawned()
    {
        pool = null;
    }

    public void OnSpawned(Vector3 p1, IMemoryPool p2)
    {
        pool = p2;
    }

    public override void Shoot()
    {
        _timeStart = Time.time;
        ShowFire(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeStart + _minimumLifeTime < Time.time)
            ShowFire(false);
    }

    void ShowFire(bool isShow)
    {
        foreach (var item in particleSystems)
        {
            if (isShow)
                item.Play();
            else
                item.Stop();
        }
    }

    [Serializable]
    public new class Settings : Weapon.Settings
    {
        public float MinimumLifeTime;
    }

    public class Factory : PlaceholderFactory<Vector3, FireBall>
    {

    }
}

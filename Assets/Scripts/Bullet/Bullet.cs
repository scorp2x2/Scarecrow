using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    protected Settings settings;
    protected float _timeStart;
    protected IMemoryPool pool;

    public virtual void Update()
    {
        transform.position -= transform.forward * settings.SpeedBullet * Time.deltaTime;

        if (Time.time - _timeStart > settings.TimeLife)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponentInParent<EnemyGUI>();
        if (enemy != null)
        {
            enemy.TakeDamage(this);
            Destroy(gameObject);
        }
    }

    [Serializable]
    public class Settings
    {
        public float Damage;
        public float TimeLife;
        public float SpeedBullet;
    }
}

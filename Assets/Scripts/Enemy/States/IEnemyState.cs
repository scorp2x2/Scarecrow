using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void EnterState();
    void ExitState();
    void Update();
    void TakeDamage(Bullet bullet);
}

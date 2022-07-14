using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
    Loot.Factory _factoryLoot;

    private void Start()
    {
        Cursor.visible = false;
    }

    [Inject]
    public void Construct(Loot.Factory factoryLoot, Gun.Factory factoryGun, FireBall.Factory factoryFireBall, WaterBall.Factory factoryWaterBall)
    {
        _factoryLoot = factoryLoot;

        var weapons = new List<Weapon>(){
            factoryGun.Create(Vector3.zero),
            factoryGun.Create(Vector3.zero),
            factoryFireBall.Create(Vector3.zero),
            factoryFireBall.Create(Vector3.zero),
            factoryWaterBall.Create(Vector3.zero),
            factoryWaterBall.Create(Vector3.zero),
            };

        for (int i = 0; i < weapons.Count; i++)
        {
            SpawnLoot(weapons[i], GetPosition(weapons.Count, i));
        }
    }

    Vector3 GetPosition(int count, int index, Vector3 point = new Vector3())
    {
        float radius = 1f;

        var ang = (360 / count) * index;
        var pos = new Vector3();
        pos.x = point.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.z = point.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }

    public void SpawnLoot(Weapon weapon, Vector3 point)
    {
        _factoryLoot.Create(point, weapon);
    }
}

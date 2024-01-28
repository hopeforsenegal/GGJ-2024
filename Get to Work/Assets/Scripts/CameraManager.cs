using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DoorToVantage{
   public Door door;
   public GameObject vantage;
   public GameObject spawn;
}

public class CameraManager : MonoBehaviour
{
    public Config config;
    public DoorToVantage[] doorToVantage;
    public GameObject vantage1;
    public GameObject vantage2;
    public GameObject spawn1;
    public GameObject spawn2;
    public Camera camera;

    void Update()
    {
        GameAlwaysAlive.DoUpdate(config);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveCamera(camera, vantage2.transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveCamera(camera, vantage1.transform);
        }

    }

    public static void MoveCamera(Camera c, Transform vantage)
    {
        var pos = vantage.transform.position;
        pos.z = c.transform.position.z;
        LeanTween.move(c.gameObject, pos, 0.3f);
    }
    public static void MovePlayer(TopDownDude player, Transform spawn)
    {
        var spawnPoint = spawn.transform.position;
        LeanTween.move(player.gameObject, spawnPoint, 0.01f);
    }

    // Collisions
    public void OnPlayerDoorCollision(TopDownDude player,Door door)
    {
        if (player != null)
        {

            Debug.Log($"I touched the {door.name}");
            foreach (var d in doorToVantage)
            {
                if(d.door == door)
                {
                    CameraManager.MoveCamera(camera, d.vantage.transform);
                    CameraManager.MovePlayer(player, d.spawn.transform);
                }
            }

        }
    }

    internal void OnBulletEnemyCollision(Enemy enemy, Bullet bullet)
    {
            Debug.Log($"Damage Amount: {1}");
            enemy.health -= 1;
            Debug.Log($"Health is now: {enemy.health}");

            if (enemy.health <= 0)
            {
                Destroy(enemy.gameObject);
            }
        Destroy(bullet.gameObject);
    }
}

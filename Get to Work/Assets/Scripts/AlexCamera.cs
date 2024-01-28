using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCamera : MonoBehaviour
{
    // Spawning
    public GameObject[] obstacles;
    int spawnFreq = 4;  // low number = high spawn frequency, high number = low spawn frequency
    int spawnRadius = 30;
    int minSpawnCount = 1;
    int maxSpawnCount = 10;
    bool notSpawned = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If at spawn line
        if ((int)transform.position.y % spawnFreq == 0)
        {
            // If not already spawned there
            if (notSpawned)
            {
                int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
                for (int i = 0; i < spawnCount; i++)
                {
                    float x = transform.position.x + Random.Range(-spawnRadius, spawnRadius);
                    float y = transform.position.y - 10f;
                    int obstacleIdx = Random.Range(0,obstacles.Length);
                    Instantiate(obstacles[obstacleIdx], new Vector3(x, y, 0), Quaternion.identity);
                }
                notSpawned = false;
            }
        }
        else
        {
            notSpawned = true;
        }
    }
}

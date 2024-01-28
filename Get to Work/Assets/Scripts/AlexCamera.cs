using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCamera : MonoBehaviour
{
    // Goals
    bool levelComplete = false;
    float goalDistance = 500.0f;
    float threshold1 = 100.0f;
    float threshold2 = 200.0f;
    float threshold3 = 300.0f;
    float threshold4 = 400.0f;

    // Spawning
    public GameObject[] obstacles;
    public GameObject[] actors;
    int spawnFreq = 4;  // low number = high spawn frequency, high number = low spawn frequency
    int spawnRadius = 30;
    int minSpawnCount = 1;
    int maxSpawnCount = 4;
    bool notSpawned = true;
    int actorSpawnTimer = 0;
    int actorSpawnFreq = 300;
    int minActorSpawnCount = 1;
    int maxActorSpawnCount = 1;

    void Update()
    {
        // Spawn thresholds
        if (transform.position.y < -threshold4)
        {
            minActorSpawnCount = 10;
            maxActorSpawnCount = 10;
            minSpawnCount = 2;
            maxSpawnCount = 10;
        }
        else if (transform.position.y < -threshold3)
        {
            minActorSpawnCount = 2;
            maxActorSpawnCount = 6;
            minSpawnCount = 2;
            maxSpawnCount = 8;
        }
        else if (transform.position.y < -threshold2)
        {
            minActorSpawnCount = 1;
            maxActorSpawnCount = 5;
            minSpawnCount = 2;
            maxSpawnCount = 6;
        }
        else if (transform.position.y < -threshold1)
        {
            minActorSpawnCount = 1;
            maxActorSpawnCount = 6;
        }

        // If at spawn line (obstacles)
        if (!levelComplete && (int)transform.position.y % spawnFreq == 0)
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

        // If time to spawn an actor
        actorSpawnTimer += 1;
        if (!levelComplete && (int)actorSpawnTimer % actorSpawnFreq == 0)
        {
            int spawnCount = Random.Range(minActorSpawnCount, maxActorSpawnCount);
            for (int i = 0; i < spawnCount; i++)
            {
                float x = transform.position.x + Random.Range(-spawnRadius, spawnRadius);
                float y = transform.position.y - 10f;
                int actorIdx = Random.Range(0, actors.Length);
                Instantiate(actors[actorIdx], new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        // Check win condition
        if (!levelComplete && transform.position.y < -goalDistance) {
            levelComplete = true;

            LeanTween.moveLocal(Camera.main.gameObject, new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, -6), 1).setOnComplete(() =>
            {
                GameAlwaysAlive.Instance.TransitionTo(GameState.IntroJumpingGame);
            });
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private List<GameObject> spawned = new List<GameObject>();
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private float spawnRate = 2;
    [SerializeField]
    private bool spawn = false;
    [SerializeField]
    private int maxSpawns = 5;

    private float spawnTimer = 0;

    public void CleanupDeadEnemies()
    {
        for (int i = 0; i < spawned.Count; i++)
        {
            if (!spawned[i])
            {
                spawned.Remove(spawned[i]);
                Debug.Log("Cleaned up");
            }
        }
    }

    public void SetSpawning(bool opt)
    {
        spawn = opt;
    }

    public void SetSpawnRate(float amount)
    {
        spawnRate = amount;
    }

    public void SetMaxSpawns(int amount)
    {
        maxSpawns = amount;
    }

    private void Awake()
    {
        spawnTimer = spawnRate;

        foreach (Transform t in transform)
        {
            spawnPoints.Add(t); //Damn the way this works is beautiful.
        }
    }


    private void Update()
    {
        if (spawn)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0 && spawned.Count <= maxSpawns)
            {
                GameObject enemySpawn = (GameObject)GameObject.Instantiate( enemies[ Random.Range( 0, enemies.Length ) ] );
                spawned.Add(enemySpawn);
                enemySpawn.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
                Vector3 p = enemySpawn.transform.position;
                p.z = 0;
                enemySpawn.transform.position = p;

                spawnTimer = spawnRate;
            }
            CleanupDeadEnemies();
        }
    }
}

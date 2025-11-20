using UnityEngine;
using System.Collections;  
using System.Collections.Generic;  

public class Spawners : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 3f; // 3 secondes entre chaque spawn
    public float spawnDistance;
    public float tempsdernierspawn;

    // Update is called once per frame
    void Update()
    {
        tempsdernierspawn += Time.deltaTime;
        if (tempsdernierspawn >= spawnRate)
        {
            SpawnEnemy();
            tempsdernierspawn = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Supprimez la condition problématique et gardez juste la logique de spawn
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnDistance;
        spawnPosition += (Vector2)transform.position;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}

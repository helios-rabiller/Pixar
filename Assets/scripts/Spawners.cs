using UnityEngine;
using System.Collections;  
using System.Collections.Generic;  

public class Spawners : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate;
    public float spawnDistance;

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (Time.frameCount % Mathf.RoundToInt(spawnRate / Time.deltaTime) == 0)
        {
            Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnDistance;
            spawnPosition += (Vector2)transform.position;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

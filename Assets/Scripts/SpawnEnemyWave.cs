using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyWave: MonoBehaviour {

    [SerializeField] GameObject[] enemies;
    [SerializeField] float spawnXOffsetRange = 20f;

    [SerializeField] float spawnYOffsetMin = 120f;
    [SerializeField] float spawnYOffsetMax = 200f;

    [SerializeField] float spawnZOffsetMin = 200f;
    [SerializeField] float spawnZOffsetMax = 400f;

    [SerializeField] GameObject parent;


    Vector3 startSpawnPosition;
    Quaternion startSpawnRotation;

    float spawnXPos;
    float spawnYPos;
    float spawnZPos;

    private void Start()

    {
        SpawnWave();
    }

    public void SpawnWave()
    {
        foreach (GameObject enemy in enemies)
        {
            GameObject SpawnedEnemy = Instantiate(enemy); // Spawn each enemy in array
            SpawnedEnemy.transform.parent = transform; // Set parent transform of each enemy to Player
            SetEnemySpawnDistance(); // Calculate random spawn position
            SpawnedEnemy.transform.localPosition = new Vector3(spawnXPos, spawnYPos, spawnZPos); // Set spawn position to random spawn position relative to player
            SpawnedEnemy.transform.parent = null; 
        }
    }

 
    private void SetEnemySpawnDistance()
    {
        spawnXPos = UnityEngine.Random.Range(-spawnXOffsetRange, spawnXOffsetRange);
        spawnYPos = UnityEngine.Random.Range(spawnYOffsetMin, spawnYOffsetMax);
        spawnZPos = UnityEngine.Random.Range(spawnZOffsetMin, spawnZOffsetMax);
    }


}
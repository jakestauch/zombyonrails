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
     
    Vector3 spawnPosition;
    Quaternion spawnRotation; 

    private void Start()

    {
        SpawnWave();
    }

    public void SpawnWave()
    {
        foreach (GameObject enemy in enemies)
        {
            SetEnemySpawnTransform();
            Instantiate(enemy, spawnPosition, spawnRotation);
        }
    }

    private void SetEnemySpawnTransform()
    {

        Vector3 playerPosition = gameObject.transform.localPosition;

        float spawnXOffset = UnityEngine.Random.Range(-spawnXOffsetRange, spawnXOffsetRange);
        float spawnYOffset = UnityEngine.Random.Range(-spawnYOffsetMin, spawnYOffsetMax);
        float spawnZOffset = UnityEngine.Random.Range(-spawnZOffsetMin, spawnZOffsetMax);

        float spawnPosX = playerPosition.x + spawnXOffset;
        float spawnPosY = playerPosition.y + spawnYOffset;
        float spawnPosZ = playerPosition.z + spawnZOffset;

        spawnPosition.Set(spawnPosX, spawnPosY, spawnPosZ);
    }

}
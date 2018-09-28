using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy: MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] float spawnXOffsetRange = 20f;

    [SerializeField] float spawnYOffsetMin = 100f;
    [SerializeField] float spawnYOffsetMax = 120f;

    [SerializeField] float spawnZOffsetMin = 100f;
    [SerializeField] float spawnZOffsetMax = 120f;

    [SerializeField] GameObject playerShip;

    float spawnXPos;
    float spawnYPos;
    float spawnZPos;


    public void SpawnEnemyInstance()
    {
        playerShip = GameObject.Find("Space Ship");
        GameObject SpawnedEnemy = Instantiate(enemy); // Spawn enemy
        SpawnedEnemy.transform.SetParent(playerShip.transform); // Set parent transform enemy to Player
        SetEnemySpawnDistance(); 
        SpawnedEnemy.transform.localPosition = new Vector3(spawnXPos, spawnYPos, spawnZPos); // Set spawn position to random spawn position relative to player
        SpawnedEnemy.transform.parent = null; // Reset transform to world space so doesn't match Player speed
    }

 
    public void SetEnemySpawnDistance()
    {
        spawnXPos = UnityEngine.Random.Range(-spawnXOffsetRange, spawnXOffsetRange);
        spawnYPos = UnityEngine.Random.Range(spawnYOffsetMin, spawnYOffsetMax);
        spawnZPos = UnityEngine.Random.Range(spawnZOffsetMin, spawnZOffsetMax);
    }

}
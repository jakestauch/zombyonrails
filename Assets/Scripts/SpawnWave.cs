using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{

    [SerializeField] int numEnemies = 5;
    [SerializeField] float timeBetweenEnemies = 1;

    // Use this for initialization
    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(StartSpawn());
        }
    }

    private IEnumerator StartSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenEnemies);
        for (int i = 0; i < numEnemies; i++)
        {
            SendMessage("SpawnEnemyInstance");
            yield return wait;
        }
    }
    
}
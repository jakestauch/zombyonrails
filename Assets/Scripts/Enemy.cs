using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Game Point System")]
    [SerializeField] int hitPointsAwarded = 25;
    [SerializeField] int deathPointsAwarded = 100;

    [Header("Enemy Health")]
    [SerializeField] int enemyHealth = 8;


    [Header("Game Objects")]
    [SerializeField] GameObject hitExplosion;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
    // Use this for initialization
    void Start ()
    {
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        HitEnemy();

        if (enemyHealth <= 0)
        {
            KillEnemy();
            scoreBoard.ScoreDeath(hitPointsAwarded);
        }

    }

    private void HitEnemy()
    {
        enemyHealth = enemyHealth - 1;
        GameObject hitFx = Instantiate(hitExplosion, transform.position, Quaternion.identity);
        hitFx.transform.parent = parent;
        scoreBoard.ScoreHit(hitPointsAwarded);
    }

    private void KillEnemy()
    {
        GameObject deathFx = Instantiate(deathExplosion, transform.position, Quaternion.identity);
        deathFx.transform.parent = parent;

        scoreBoard.ScoreDeath(hitPointsAwarded);
        Destroy(gameObject);
    }

}

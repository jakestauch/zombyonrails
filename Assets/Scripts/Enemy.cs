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

    [SerializeField] float speed = 10f; //todo add speed in different dimensions so goes down first
    //todo set transform to local position of player
    //todo destroy after flyby

    ScoreBoard scoreBoard;
    Transform target; 

    GameObject player;
    // Use this for initialization
    void Start ()
    {
        AddBoxCollider();
        player = GameObject.Find("Player Rig");
        target = player.transform;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void Update()

    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(target);
    }

    private void AddBoxCollider()
    {
        AddNonTriggerBoxCollider();
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

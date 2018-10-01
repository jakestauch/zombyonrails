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

    [SerializeField] float xSpeed = 1f;
    [SerializeField] float ySpeed = 100f;
    [SerializeField] float zSpeed = 10f;


    float xMovementPerFrame;
    float yMovementPerFrame;
    float zMovementPerFrame;

    ScoreBoard scoreBoard;
    Transform target; 
    [SerializeField] GameObject followObject;
    Vector3 EnemyMovementPerFrame;

    // Use this for initialization
    void Start ()
    {
        followObject = GameObject.Find("Enemy Follow Target");
        target = followObject.transform;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void Update()

    {
        xMovementPerFrame = Mathf.MoveTowards(transform.position.x, followObject.transform.position.x, xSpeed * Time.deltaTime);
        yMovementPerFrame = Mathf.MoveTowards(transform.position.y, followObject.transform.position.y, ySpeed * Time.deltaTime);
        zMovementPerFrame = Mathf.MoveTowards(transform.position.z, followObject.transform.position.z, zSpeed * Time.deltaTime);

        transform.position = new Vector3(xMovementPerFrame, yMovementPerFrame, zMovementPerFrame);
        transform.LookAt(target);
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

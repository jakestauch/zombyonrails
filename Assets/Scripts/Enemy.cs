using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int hitValue = 25;
    [SerializeField] GameObject explosion;
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
    //Test

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(explosion, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        scoreBoard.ScoreHit(hitValue);
    }

   
}

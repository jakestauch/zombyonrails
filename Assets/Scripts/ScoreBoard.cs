using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    int score;
    Text scoreText;

	// Use this for initialization
	void Start () 
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () 
    {
       
    }
   
    public void ScoreHit(int hitValue)
    {
        score = score + hitValue;
        scoreText.text = "Score: " + score.ToString();
    }

    public void ScoreDeath(int deathValue)
    {
        score = score + deathValue;
        scoreText.text = "Score: " + score.ToString();
    }

    public void StoreScore()
    {
        PlayerPrefs.SetInt("score", score);
    }
}

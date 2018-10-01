using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

    int score;

    Text scoreText; 

    // Use this for initialization

    void Start () 
    {
        score = PlayerPrefs.GetInt("score");
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
    }
	

}

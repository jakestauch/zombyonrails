using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class WinGame : MonoBehaviour
{
    ScoreBoard scoreBoard;

    void OnEnable()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        scoreBoard.StoreScore();
        SceneManager.LoadScene(3);
    }

}


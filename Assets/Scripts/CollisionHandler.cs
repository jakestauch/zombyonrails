using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 0.5f;
    [Tooltip("Explosion Effect")][SerializeField] GameObject deathFX; 

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("LoadGameOver", levelLoadDelay);

    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }

}

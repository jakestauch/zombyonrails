﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {


	// Use this for initialization
	void Start () 
    {
        Invoke("LoadFirstLevel", 2f);
    }
	

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
    }
}

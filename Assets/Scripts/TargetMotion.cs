using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMotion : MonoBehaviour
{

    [SerializeField] float circlePeriod;
    [SerializeField] float circleSize;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / circlePeriod;
        float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau) * circleSize;

        transform.localPosition = new Vector3(rawSinWave, rawSinWave, 0);
    }
}
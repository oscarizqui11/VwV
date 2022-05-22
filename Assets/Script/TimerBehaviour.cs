using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerBehaviour : MonoBehaviour
{
    public float timeLimit;

    public static Action<float> SendTime = delegate { };

    private Text _text;
    private Tests _evmg;


    // Start is called before the first frame update
    void Start()
    {
        _evmg = FindObjectOfType<Tests>();
        _text = GetComponent<Text>();
        _text.text = "Time " + (Mathf.Round(timeLimit * 100f) / 100f);
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Time " + (Mathf.Round(timeLimit * 100f) / 100f);
    }

    private void OnGUI()
    {
        SendTime(timeLimit);
    }

    private void FixedUpdate()
    {
        if(!_evmg.GetGameOver())
        {
            timeLimit = timeLimit + Time.fixedDeltaTime;        
        }
    }
}

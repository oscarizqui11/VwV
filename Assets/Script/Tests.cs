using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    private float timer;
    private bool isGameOver;

    private void Start()
    {
        isGameOver = false;
    }

    private void OnEnable()
    {
        TimerBehaviour.SendTime += getTime;
        PlayerController.gameOver += Esparta;
    }

    private void OnDisable()
    {
        TimerBehaviour.SendTime -= getTime;
        PlayerController.gameOver -= Esparta;
    }

    private void Esparta()
    {
        if (!isGameOver)
        {
            Debug.Log("GAME OVER!");
            Debug.Log("Yor Time: " + timer);

            isGameOver = true;
        }
    }

    private void getTime(float t)
    {
        timer = t;
    }

    public bool GetGameOver()
    {
        return isGameOver;
    }
}

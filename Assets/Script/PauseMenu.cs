using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource _mainMusic;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        _mainMusic.spatialBlend = 0;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        _mainMusic.spatialBlend = 0.86f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        StateDataController.checkpoint = null;
        StateDataController.isFruitEaten_1 = false;
        StateDataController.isFruitEaten_2 = false;
        StateDataController.isFruitEaten_3 = false;
        StateDataController.isFruitEaten_4 = false;
        StateDataController.isFruitEaten_5 = false;
        StateDataController.isFruitEaten_6 = false;
        StateDataController.isFruitEaten_7 = false;
        Time.timeScale = 1;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
    }
}

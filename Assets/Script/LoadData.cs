using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    //public int numFile;

    public void LoadDataFile(int numFile)
    {
        DBManager.ReadFile(numFile);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

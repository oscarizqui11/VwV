using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    //public int numFile;

    public void SaveDataFile(int numFile)
    {
        DBManager.SaveCheckpointDB(numFile);

        CollectablesController[] fruits = GameObject.Find("Frutas").GetComponentsInChildren<CollectablesController>(true);

        StateDataController.isFruitEaten_1 = !fruits[0].gameObject.activeInHierarchy;
        StateDataController.isFruitEaten_2 = !fruits[1].gameObject.activeInHierarchy;
        StateDataController.isFruitEaten_3 = !fruits[2].gameObject.activeInHierarchy;
        StateDataController.isFruitEaten_4 = !fruits[3].gameObject.activeInHierarchy;
        StateDataController.isFruitEaten_5 = !fruits[4].gameObject.activeInHierarchy;
        StateDataController.isFruitEaten_6 = !fruits[5].gameObject.activeInHierarchy;
        StateDataController.isFruitEaten_7 = !fruits[6].gameObject.activeInHierarchy;
        DBManager.SaveFruitstDB(numFile);
    }
}

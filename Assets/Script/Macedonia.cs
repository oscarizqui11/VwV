using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macedonia : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CollectablesController[] frutas = GetComponentsInChildren<CollectablesController>();

        if (StateDataController.isFruitEaten_1) { frutas[0].gameObject.SetActive(false); } else { frutas[0].gameObject.SetActive(true); }
        if (StateDataController.isFruitEaten_2) { frutas[1].gameObject.SetActive(false); } else { frutas[1].gameObject.SetActive(true); }
        if (StateDataController.isFruitEaten_3) { frutas[2].gameObject.SetActive(false); } else { frutas[2].gameObject.SetActive(true); }
        if (StateDataController.isFruitEaten_4) { frutas[3].gameObject.SetActive(false); } else { frutas[3].gameObject.SetActive(true); }
        if (StateDataController.isFruitEaten_5) { frutas[4].gameObject.SetActive(false); } else { frutas[4].gameObject.SetActive(true); }
        if (StateDataController.isFruitEaten_6) { frutas[5].gameObject.SetActive(false); } else { frutas[5].gameObject.SetActive(true); }
        if (StateDataController.isFruitEaten_7) { frutas[6].gameObject.SetActive(false); } else { frutas[6].gameObject.SetActive(true); }
    }
}

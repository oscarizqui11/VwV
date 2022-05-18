using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelBehaviour : MonoBehaviour
{
    private Camera _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        _mainCamera.transform.position = new Vector3(0, _mainCamera.transform.position.y - _mainCamera.transform.localScale.y, _mainCamera.transform.position.z);
    }

}

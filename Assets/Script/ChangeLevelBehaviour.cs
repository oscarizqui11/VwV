using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelBehaviour : MonoBehaviour
{
    private Camera _mainCamera;

    private float vertilcalCamSize;
    private float horizontalCamSize;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;

        vertilcalCamSize = Camera.main.orthographicSize * 2.0f;
        horizontalCamSize = vertilcalCamSize * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y - _mainCamera.transform.position.y < -vertilcalCamSize / 2)
        {
            _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y - vertilcalCamSize, _mainCamera.transform.position.z);
        }
        else if (transform.position.y - _mainCamera.transform.position.y > vertilcalCamSize / 2)
        {
            _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y + vertilcalCamSize, _mainCamera.transform.position.z);
        }
        else if (transform.position.x - _mainCamera.transform.position.x < -horizontalCamSize / 2)
        {
            _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x - horizontalCamSize, _mainCamera.transform.position.y, _mainCamera.transform.position.z);
        }
        else if (transform.position.x - _mainCamera.transform.position.x > horizontalCamSize / 2)
        {
            _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x + horizontalCamSize, _mainCamera.transform.position.y, _mainCamera.transform.position.z);
        }

    }
}

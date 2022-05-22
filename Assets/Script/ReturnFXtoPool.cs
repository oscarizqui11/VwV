using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFXtoPool : MonoBehaviour
{
    private AudioSource _audS;

    private void Start()
    {
        _audS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log(_audS.time);
        if(_audS.time > _audS.clip.length)
        {
            gameObject.SetActive(false);
        }
    }
}

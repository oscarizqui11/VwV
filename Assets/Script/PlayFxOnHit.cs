using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFxOnHit : MonoBehaviour
{
    public AudioSource _audS;

    private void Start()
    {
        _audS = GetComponent<AudioSource>();
    }

    public void PlayFX()
    {
        _audS.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool flipXonRespawn;

    private Animator _anim;
    public AudioSource _audS;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _audS = GetComponent<AudioSource>();

        Transform respawnCheckPoint = FindObjectOfType<RespawnBehaviour>().checkPoint;

        if(respawnCheckPoint == transform)
        {
            if (respawnCheckPoint.name != "Initial Spawn")
            {
                respawnCheckPoint.GetComponent<Animator>().SetLayerWeight(1, 0);
                _anim.SetLayerWeight(1, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!(collision.GetComponent<RespawnBehaviour>().checkPoint.name == transform.name))
        {
            if (collision.GetComponent<RespawnBehaviour>().checkPoint.name != "Initial Spawn")
            {
                collision.GetComponent<RespawnBehaviour>().checkPoint.GetComponent<Animator>().SetLayerWeight(1, 0);
            }
            _anim.SetLayerWeight(1, 1);
            collision.GetComponent<RespawnBehaviour>().SetCheckPoint(transform);
            _audS.Play();
        }
    }
}

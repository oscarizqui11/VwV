using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{

    public Transform checkPoint;
    private SpriteRenderer _sprt;

    // Start is called before the first frame update
    void Start()
    {
        _sprt = GetComponent<SpriteRenderer>();
    }

    public void SetCheckPoint(Transform newCheckPoint)
    {
        checkPoint = newCheckPoint;
    }

    public void Respawn()
    {
        transform.position = checkPoint.position;
        _sprt.flipX = checkPoint.GetComponent<CheckPoint>().flipXonRespawn;
    }
}

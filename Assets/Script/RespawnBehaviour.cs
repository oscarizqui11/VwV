using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{

    public Transform checkPoint;
    private SpriteRenderer _sprt;
    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        _sprt = GetComponent<SpriteRenderer>();
        _rb2d = GetComponent<Rigidbody2D>();

        Respawn();
    }

    public void SetCheckPoint(Transform newCheckPoint)
    {
        checkPoint = newCheckPoint;
    }

    public void Respawn()
    {
        transform.position = checkPoint.position;
        _sprt.flipX = checkPoint.GetComponent<CheckPoint>().flipXonRespawn;
        if(_rb2d.gravityScale < 0)
        {
            _rb2d.gravityScale = -_rb2d.gravityScale;
            _rb2d.transform.Rotate(new Vector3(180, 0, 0));
        }
    }
}

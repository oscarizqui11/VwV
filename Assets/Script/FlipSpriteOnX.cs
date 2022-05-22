using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSpriteOnX : MonoBehaviour
{
    private MovilePlatform _mvplatf;
    private Rigidbody2D _rb2d;

    public bool flippedX;
    public bool flippedY;

    // Start is called before the first frame update
    void Start()
    {
        _mvplatf = GetComponent<MovilePlatform>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_mvplatf.nextPointDir.x > 0 && !flippedX)
        {
            transform.Rotate(new Vector3(0, 1, 0), 180);
            flippedX = true;
        }
        else if(_mvplatf.nextPointDir.x < 0 && flippedX)
        {
            transform.Rotate(new Vector3(0, 1, 0), 180);
            flippedX = false;
        }

        if(_rb2d.gravityScale < 0 && !flippedY)
        {
            transform.Rotate(new Vector3(1, 0, 0), 180);
            flippedY = true;
        }
        else if (_rb2d.gravityScale >= 0 && flippedY)
        {
            transform.Rotate(new Vector3(1, 0, 0), 180);
            flippedY = false;
        }
    }
}

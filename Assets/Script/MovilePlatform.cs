using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovilePlatform : MonoBehaviour
{

    private Transform[] _points;
    private MovementBehaviour _mv;

    private int pointIndex;
    private Vector3 nextPointDir;

    // Start is called before the first frame update
    void Start()
    {     
        
        _points = GetComponentsInChildren<Transform>();
        _mv = GetComponent<MovementBehaviour>();

        pointIndex = 1;

        nextPointDir = _points[pointIndex].GetComponent<MovementPoints>().initialPos - transform.position;

        Debug.Log(_points[0].position);
        Debug.Log(_points[1].position);
        Debug.Log(_points[2].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPositionReached())
        {
            _mv.MoveTowards(nextPointDir.normalized);
        }
        else
        {
            if(pointIndex == 1)
            {
                pointIndex = 2;
            }
            else if(pointIndex == 2)
            {
                pointIndex = 1;
            }

            nextPointDir = _points[pointIndex].GetComponent<MovementPoints>().initialPos - transform.position;
        }
    }
    private bool IsPositionReached()
    {
        return Vector3.Distance(transform.position, _points[pointIndex].GetComponent<MovementPoints>().initialPos) <= Vector3.Distance(NextPosition(), _points[pointIndex].GetComponent<MovementPoints>().initialPos);
    }

    private Vector3 NextPosition()
    {
        return transform.position + nextPointDir * _mv.velocity * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().onPlatform = true;
        collision.gameObject.GetComponent<PlayerController>().platformDir = nextPointDir;

        collision.gameObject.GetComponent<PlayerController>().collidingPLatform = gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().onPlatform = false;
        collision.gameObject.GetComponent<PlayerController>().platformDir = Vector3.zero;

        collision.gameObject.GetComponent<PlayerController>().collidingPLatform = null;
    }
}

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().direction.x = collision.gameObject.GetComponent<PlayerController>().direction.x + nextPointDir.x;
        collision.gameObject.GetComponent<PlayerController>().direction.x = collision.gameObject.GetComponent<PlayerController>().direction.y + nextPointDir.y;

        Debug.Log(collision.gameObject.GetComponent<PlayerController>().direction.x);
        Debug.Log(collision.gameObject.GetComponent<PlayerController>().direction.y);
    }*/


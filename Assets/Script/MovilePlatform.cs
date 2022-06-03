using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovilePlatform : MonoBehaviour
{

    private Transform[] _points;
    private MovementBehaviour _mv;

    private int pointIndex;
    public Vector3 nextPointDir;

    // Start is called before the first frame update
    void Start()
    {     
        
        _points = GetComponentsInChildren<Transform>();
        _mv = GetComponent<MovementBehaviour>();

        pointIndex = 1;

        nextPointDir = _points[pointIndex].GetComponent<MovementPoints>().initialPos - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
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
    public bool IsPositionReached()
    {
        return Vector3.Distance(transform.position, _points[pointIndex].GetComponent<MovementPoints>().initialPos) <= Vector3.Distance(NextPosition(), _points[pointIndex].GetComponent<MovementPoints>().initialPos);
    }

    private Vector3 NextPosition()
    {
        return transform.position + nextPointDir * _mv.velocity * Time.deltaTime;
    }
}


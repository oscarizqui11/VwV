using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float velocity;

    private Rigidbody2D _rb2d;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void RotateDirection(Vector3 dir, float initialRotation)
    {
        //Vector3 dir = Route.pointsList[currentPoint + 1].position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - initialRotation);
    }

    public void MoveTowards(Vector3 dir)
    {
        transform.position = transform.position + velocity * dir * Time.fixedDeltaTime;
    }

    public void MoveRB(Vector3 dir)
    {
        if (!WillCollide(dir))
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + velocity * Time.fixedDeltaTime * dir);
        }
    }

    public void MoveVelocity(Vector3 dir)
    {
        _rb2d.velocity = dir;
    }

    private bool WillCollide(Vector3 dir)
    {
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(TryGetComponent<CompositeCollider2D>(out CompositeCollider2D compositeCol) && compositeCol.IsTouching(collision))
        {
            collision.GetComponent<RespawnBehaviour>().Respawn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<RespawnBehaviour>().Respawn();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySurface : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().transform.SetParent(null);
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Wiiiiii!");
            collision.gameObject.GetComponent<MovementBehaviour>().MoveRB(collision.transform.position + GetComponent<MovementBehaviour>().velocity * Time.fixedDeltaTime * GetComponent<MovilePlatform>().nextPointDir.normalized);
        }
    }*/
}

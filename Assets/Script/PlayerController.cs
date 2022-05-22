using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PlayerController : MonoBehaviour
{
    public int spriteRotation;

    private Animator _anim;
    private SpriteRenderer _sprt;
    private MovementBehaviour _mv;
    private Rigidbody2D _rb2d;
    private RespawnBehaviour _respawn;
    public GameObject _collectables;
    private AudioSource _audS;
    private static Camera mainCamera;

    public Vector3 direction;
    private Vector3 cameraDir;

    public delegate void Tests();
    public static event Tests gameOver;

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _sprt = GetComponent<SpriteRenderer>();
        _mv = GetComponent<MovementBehaviour>();
        _rb2d = GetComponent<Rigidbody2D>();
        _respawn = GetComponent<RespawnBehaviour>();
        _audS = GetComponent<AudioSource>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        bool fire = Input.GetButtonDown("Fire1");
        direction = new Vector3(hor, 0);

        if (hor > 0.1)
        {
            _sprt.flipX = false;
            _anim.SetBool("Walking", true);

        }
        else if(hor < -0.1)
        {
            _sprt.flipX = true;
            _anim.SetBool("Walking", true);
        }
        else
        {
            _anim.SetBool("Walking", false);
        }

        if(jump)
        {
            _rb2d.gravityScale = -_rb2d.gravityScale;
        }

        if(jump)
        {
            _audS.Play();
            _anim.SetTrigger("Flip");
            _rb2d.transform.Rotate(new Vector3(180, 0, 0));
        }

        if (fire)
        {
            _respawn.Respawn();
            if(_rb2d.gravityScale < 0)
            {
                _rb2d.gravityScale = -_rb2d.gravityScale;
            }
        }

        if(!_collectables.GetComponentInChildren<CollectablesController>())
        {
            if(gameOver != null)
            {
                gameOver();
            }
        }
    }

    private void FixedUpdate()
    {
        _mv.MoveRB(direction.normalized);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            _anim.SetBool("Falling", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            _anim.SetBool("Falling", true);
        }
    }
}

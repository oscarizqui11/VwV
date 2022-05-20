using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int spriteRotation;

    private Animator _anim;
    private SpriteRenderer _sprt;
    private MovementBehaviour _mv;
    private Rigidbody2D _rb2d;
    private RespawnBehaviour _respawn;
    public GameObject _collectables;
    private static Camera mainCamera;

    public Vector3 direction;
    private Vector3 cameraDir;

    public GameObject collidingPLatform;

    public bool onPlatform;
    public Vector3 platformDir;

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _sprt = GetComponent<SpriteRenderer>();
        _mv = GetComponent<MovementBehaviour>();
        _rb2d = GetComponent<Rigidbody2D>();
        _respawn = GetComponent<RespawnBehaviour>();
        mainCamera = Camera.main;
        onPlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        bool fire = Input.GetButtonDown("Fire1");
        UpdateDirection(new Vector3(hor, 0));

        if (hor > 0.1)
        {
            //_anim.SetInteger("State", 1);
            //_anim.SetBool("IsWalking", true);
            //_mv.RotateDirection(direction.normalized, spriteRotation);
            _sprt.flipX = false;
            _anim.SetBool("Walking", true);

        }
        else if(hor < -0.1)
        {
            _sprt.flipX = true;
            _anim.SetBool("Walking", true);
            //_anim.SetInteger("State", 0);
            //_anim.SetBool("IsWalking", false);
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
            Debug.Log("Game Over");
        }

    }

    private void FixedUpdate()
    {
        _mv.MoveRB(direction.normalized);
    }

    public void UpdateDirection(Vector3 dirUpdate)
    {
        if(!collidingPLatform)
        {
            direction = new Vector3(dirUpdate.x + platformDir.x, dirUpdate.y + platformDir.y);
        }
        else
        {
            direction = new Vector3(dirUpdate.x + platformDir.x, dirUpdate.y + platformDir.y);
        }
    }
}

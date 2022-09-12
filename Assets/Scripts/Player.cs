 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;

    [SerializeField] private float jumpForce = 20f;

    private float _movementX;
    
    private Rigidbody2D _rb;

    private SpriteRenderer _sr;

    private Animator _anim;
    
    private Canvas _canvas;

    private string WALK_ANIMATION = "isWalk";
    private string JUMP_ANIMATION = "isJump";
    
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool _isGrounded = true;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        _canvas.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        PlayerMovement();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMovement()
    {
        _movementX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(_movementX, 0, 0) * (Time.deltaTime * moveForce);
    }

    void AnimatePlayer()
    {
        //Player going to right side 
        if (_movementX > 0)
        {
            _anim.SetBool(WALK_ANIMATION, true);
            _sr.flipX = false;
        } 
        //Player going to left side
        else if (_movementX < 0)
        {
            _anim.SetBool(WALK_ANIMATION, true);
            _sr.flipX = true;
        }
        //Player isn't moving
        else
        {
            _anim.SetBool(WALK_ANIMATION,false);
        }

        if (_isGrounded == false)
        {
            _anim.SetBool(JUMP_ANIMATION, true);
        }
        else
        {
            _anim.SetBool(JUMP_ANIMATION, false);
        }
    }
    
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isGrounded = false;
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(GROUND_TAG))
            _isGrounded = true;
        if (col.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            _canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            _canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
            
    }
}

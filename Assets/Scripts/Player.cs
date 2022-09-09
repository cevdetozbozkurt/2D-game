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

    private string WALK_ANIMATION = "isWalk";
    private string GROUND_TAG = "Ground";

    private bool _isGrounded = true;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
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
        {
            _isGrounded = true;
        }
    }
}
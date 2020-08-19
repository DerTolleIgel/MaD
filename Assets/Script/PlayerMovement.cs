using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;

    public GameObject player1;
    public GameObject player2;


    public float speed = 10;
    public float jumpPower = 3;    
    private Vector2 move1;
    private Vector2 move2;

    private bool jump1;
    private bool jump2;
    private bool jumpdown1;
    private bool jumpdown2;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;




    private void Awake()
    {
        controls = new PlayerControls();

        controls.GamePlay.Player1Move.performed += ctx => move1 = ctx.ReadValue<Vector2>();
        controls.GamePlay.Player2Move.performed += ctx => move2 = ctx.ReadValue<Vector2>();
        controls.GamePlay.Player1Move.canceled += ctx => move1 = Vector2.zero;
        controls.GamePlay.Player2Move.canceled += ctx => move2 = Vector2.zero; 

        controls.GamePlay.Player1Jump.started += ctx => jump1 = true;
        controls.GamePlay.Player2Jump.started += ctx => jump2 = true;
        controls.GamePlay.Player1Jump.performed += ctx => jumpdown1 = true;
        controls.GamePlay.Player2Jump.performed += ctx => jumpdown2 = true;
        controls.GamePlay.Player1Jump.canceled += ctx => jumpdown1 = false;
        controls.GamePlay.Player2Jump.canceled += ctx => jumpdown2 = false;

        rb1 = player1.GetComponent<Rigidbody2D>();
        rb2 = player2.GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    private void OnDisable()
    {
        controls.GamePlay.Disable();
    }

    private void Update()
    {
        //bool mayJump = false;
        //if (jump1)
        //{
        //    mayJump = player1.GetComponent<BoxCollider2D>().IsTouchingLayers(-1);
        //    if (mayJump)
        //    player1.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpPower;
        //    jump1 = false;
        //}
        //if (jump2)
        //{
        //    mayJump = player2.GetComponent<BoxCollider2D>().IsTouchingLayers(-1);
        //    if (mayJump)
        //    player2.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpPower;
        //    jump2 = false;
        //}
    }

    void FixedUpdate()
    {
        bool mayJump;
        float h;
        float v;
        //player 1
        h = move1.x;
        if (h > 0) player1.transform.eulerAngles = new Vector3(0, 0, 0);
        if (h < 0) player1.transform.eulerAngles = new Vector3(0, 180, 0);
        v = rb1.velocity.y;
        if (jump1)
        {
            mayJump = player1.GetComponent<BoxCollider2D>().IsTouchingLayers(-1);
            if (mayJump)
            {
                v = jumpPower;
                player1.GetComponent<AudioSource>().Play();
            }
            jump1 = false;
        }
        

        if (v < 0)
        {
            v += Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (!jumpdown1)
        {
            v += Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        Vector2 dir = new Vector2(h * speed, v);
        rb1.velocity = dir;

        // player 2        
        h = move2.x;
        if (h > 0) player2.transform.eulerAngles = new Vector3(0, 0, 0);
        if (h < 0) player2.transform.eulerAngles = new Vector3(0, 180, 0);
        v = rb2.velocity.y;
        if (jump2)
        {
            mayJump = player2.GetComponent<BoxCollider2D>().IsTouchingLayers(-1);
            if (mayJump)
            {
                v = jumpPower;
                player2.GetComponent<AudioSource>().Play();
            }
            jump2 = false;
        }

        if (v < 0)
        {
            v += Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (!jumpdown2)
        {
            v += Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        dir = new Vector2(h * speed, v);
        rb2.velocity = dir;

    }

}

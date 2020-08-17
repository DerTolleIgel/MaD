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
    public float jumpTicks = 10;
    private bool inJump1 = false;
    private float inJumpTime1 = 0;

    private bool inJump2 = false;
    private float inJumpTime2 = 0;



    private Vector2 move1;
    private Vector2 move2;
    private bool jump1;
    private bool jump2;



    private void Awake()
    {
        controls = new PlayerControls();

        controls.GamePlay.Player1Move.performed += ctx => move1 = ctx.ReadValue<Vector2>();
        controls.GamePlay.Player2Move.performed += ctx => move2 = ctx.ReadValue<Vector2>();
        controls.GamePlay.Player1Move.canceled += ctx => move1 = Vector2.zero;
        controls.GamePlay.Player2Move.canceled += ctx => move2 = Vector2.zero;

        controls.GamePlay.Player1Jump.performed += ctx => jump1 = true; //onPlayer1Jump();
        controls.GamePlay.Player2Jump.performed += ctx => jump2 = true;//onPlayer2Jump();
        controls.GamePlay.Player1Jump.canceled += ctx => jump1 = false;
        controls.GamePlay.Player2Jump.canceled += ctx => jump2 = false;
    }

    private void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    private void OnDisable()
    {
        controls.GamePlay.Disable();
    }

    void FixedUpdate()
    {
                
        Rigidbody2D rb = player1.GetComponent<Rigidbody2D>();
        float h = move1.x;
        if (h > 0) player1.transform.eulerAngles = new Vector3(0, 0, 0);
        if (h < 0) player1.transform.eulerAngles = new Vector3(0, 180, 0);
        float v = rb.velocity.y;

        bool mayJump = player1.GetComponent<BoxCollider2D>().IsTouchingLayers(-1);
        
        if (jump1 && (mayJump || inJump1 ) )
        {

            if (inJumpTime1 == 0)
                v += jumpPower;
            else v += jumpPower / 2;

            inJumpTime1 = inJumpTime1 + 1;
            //Debug.Log("JumpTime " + inJumpTime + " // " + Time.time);
            if (inJumpTime1 >= jumpTicks) {
                inJump1 = false; 
                inJumpTime1 = 0;
            }
            else
            { 
                inJump1 = true;
            }
        };

        Vector2 dir = new Vector2(h* speed, v);
        player1.GetComponent<Rigidbody2D>().velocity = dir;

        // player 2

        rb = player2.GetComponent<Rigidbody2D>();
        h = move2.x;
        if (h > 0) player2.transform.eulerAngles = new Vector3(0, 0, 0);
        if (h < 0) player2.transform.eulerAngles = new Vector3(0, 180, 0);
        v = rb.velocity.y;

        mayJump = player2.GetComponent<BoxCollider2D>().IsTouchingLayers(-1);

        if (jump2 && (mayJump || inJump2))
        {

            if (inJumpTime2 == 0)
                v += jumpPower;
            else v += jumpPower / 2;

            inJumpTime2 = inJumpTime2 + 1;
            //Debug.Log("JumpTime " + inJumpTime + " // " + Time.time);
            if (inJumpTime2 >= jumpTicks)
            {
                inJump2 = false;
                inJumpTime2 = 0;
            }
            else
            {
                inJump2 = true;
            }
        };

        dir = new Vector2(h * speed, v);
        player2.GetComponent<Rigidbody2D>().velocity = dir;

    }

}

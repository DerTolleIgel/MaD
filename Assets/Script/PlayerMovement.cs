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

    }

    void FixedUpdate()
    {
        jump(ref player1, ref move1, ref rb1, ref jump1, ref jumpdown1);
        jump(ref player2, ref move2, ref rb2, ref jump2, ref jumpdown2);

    }

    /**
     * TODO: write a comment
    **/ 
    private void jump(ref GameObject player, ref Vector2 move, ref Rigidbody2D rb, ref bool jump, ref bool jumpdown)
    {
        bool mayJump;
        float h;
        float v;

        h = move.x;
        if (h > 0) player.transform.eulerAngles = new Vector3(0, 0, 0);
        if (h < 0) player.transform.eulerAngles = new Vector3(0, 180, 0);
        v = rb.velocity.y;
        if (jump)
        {            
            mayJump = player.GetComponent<BoxCollider2D>().IsTouchingLayers(Physics2D.GetLayerCollisionMask(9));
            if (mayJump)
            {
                v = jumpPower;
                player.GetComponent<AudioSource>().Play();
            }
            jump = false;
        }

        if (v < 0)
        {
            v += Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (!jumpdown)
        {
            v += Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        Vector2 dir = new Vector2(h * speed, v);
        rb.velocity = dir;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpPower = 3;
    public float jumpTicks = 10;
    private bool inJump = false;
    private float inJumpTime = 0;

    void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float h = Input.GetAxis("Horizontal");
        float v = rb.velocity.y;
        
        

        bool jump = Input.GetButton("Jump");
        
        if (jump && (v == 0 || inJump ) )
        {

            if (inJumpTime == 0)
                v += jumpPower;
            else v += jumpPower / 2;

            inJumpTime = inJumpTime + 1;
            Debug.Log("JumpTime " + inJumpTime + " // " + Time.time);
            if (inJumpTime >= jumpTicks) {
                inJump = false; 
                inJumpTime = 0;
            }
            else
            { 
                inJump = true;
            }
        };
        


        Vector2 dir = new Vector2(h* speed, v);
        GetComponent<Rigidbody2D>().velocity = dir;


    }
}

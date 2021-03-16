using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Actor : MonoBehaviour
{
    [Header("Moving")]
    public float speed; //Speed of which the actor moves

    [Header("Jumping")]
    public float jumpForce; //Force needed for actor jump
    public Transform isGroundedChecker; //Place to check grounded from
    public float checkGroundRadius; //Radius of ground checker
    public LayerMask groundLayer; //Layer ground is on
    public float coyoteTime; //How long the player can not be touching ground but can still jump
    float lastTimeGrounded; //What time the player was last grounded
    bool isGrounded; //If the player is grounded

    [Header("Advanced Jumping Settings")]
    public bool advancedJumping = true;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb; //RigidBody2D referance

    private void Start()
    {
        TryGetComponent<Rigidbody2D>(out rb); //Try to get a RigidBody2D from the actor
    }

    public void Move(float x) //Move function which takes a value for x
    {
        float moveBy = x * speed; //Set how far the actor moves to be x multiplied by speed
        rb.velocity = new Vector2(moveBy, rb.velocity.y); //Set the actors x velocity
    }

    public void Jump() //Jump function
    {
        if (isGrounded || Time.time - lastTimeGrounded <= coyoteTime) //If the actor is grounded
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //Set the actors y velocity
        }
    }

    public void IsGrounded()
    {
        Collider2D col = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); //Check is there is a collider near the ground checker

        if (col != null) //If there is a collider near ground checker
        {
            isGrounded = true;
            //return true; //Return true
        }
        else
        {
            if (isGrounded)
                lastTimeGrounded = Time.time;
            isGrounded = false;
        }


        //return false; //If all code paths return false then return false
    }

    public void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}

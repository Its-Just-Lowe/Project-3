using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    private void Update()
    {
        Move(Input.GetAxisRaw("Horizontal")); //Move player on the horizontal axis

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) //Check for jump input
            Jump(); //Call jump function

        IsGrounded();

        if (advancedJumping)
            BetterJump(); //Call betterjump function
    }
}

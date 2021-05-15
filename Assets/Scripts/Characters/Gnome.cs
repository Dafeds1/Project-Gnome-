using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : Character
{
    public float jumpForce;

    private void Awake()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        XAxesMove(Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();
        }
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        bool isGrounded = IsGrounded();
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("takeOff");

        }

        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }
}

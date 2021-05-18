using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : Character
{
    public float jumpForce;

    [SerializeField] private CollisionTester collisionTester;
    [SerializeField] private Weapon weapon1;
    private bool isGrounded;

    private void Awake()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        //
        if (!isGrounded && collisionTester.collisionCount >= 1)
        {
            XAxesMove(0);
        }
        else
        {
            XAxesMove(Input.GetAxis("Horizontal"));
        }
    }

    private void Update()
    {
        isGrounded = IsGrounded();

        Jump();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Atack2();
        }
    }

    protected override void Atack()
    {
        if (weapon1.Attack())
            base.Atack();
    }

    private void Atack2()
    {
        animator.SetTrigger("attack2");
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        HealthBar.instance.ChangeHaelth(hp);
    }

    private void Jump()
    {
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetTrigger("takeOff");
            }
        }
        else
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
    }
}

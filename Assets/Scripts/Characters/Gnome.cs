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
    }

    protected override void Atack()
    {
        if (weapon1.Attack())
            base.Atack();
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
        }
    }
}

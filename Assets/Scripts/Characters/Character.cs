using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  *** нужен енум side{ enemy ally neutral}
// корневой класс всех существ

public class Character : MonoBehaviour
{
    protected string name;
    public int maxHp;
    public int hp { get; protected set;}

    public bool facingRight { get; private set; } = true;
    public float xAxesSpeed;
    public float groundCheckRadius;
    public LayerMask groundMask;

    protected Animator animator;
    protected Rigidbody2D rb;

    public void Initialize()
    {
        hp = maxHp;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected void XAxesMove(float moveInput)
    {
        rb.velocity = new Vector2(moveInput * xAxesSpeed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }

    protected virtual void Atack()
    {
        animator.SetTrigger("attack1");
    }

    public virtual void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} с {hp} HP, получил {damage} урона");
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    protected void Die()
    {
        GameObject.Destroy(gameObject);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    protected bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundMask);
    }
}


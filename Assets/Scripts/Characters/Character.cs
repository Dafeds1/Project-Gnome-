using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  *** нужен енум side{ enemy ally neutral}
// корневой класс всех существ

public class Character : MonoBehaviour
{
    public string name;
    public int maxHp;
    public int hp { get; protected set;}
    public float stunTimer = 0;
    public bool isStun = false;

    public bool facingRight { get; private set; } = true;
    public float xAxesSpeed;
    public float groundCheckRadius;
    public LayerMask groundMask;
    public Animator animator;

    protected Rigidbody2D rb;

    public void Initialize()
    {
        hp = maxHp;
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
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
        animator.SetTrigger("attack");
    }

    public virtual void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} с {hp} HP, получил {damage} урона");
        hp -= damage;
        animator.SetTrigger("takeDamage");
        if (hp <= 0)
            Die();
    }

    protected void Die()
    {
        if (animator == null)
            Debug.Log("Жопа!!");
        animator.SetTrigger("dying");
        //GameObject.Destroy(gameObject);       //  *** удаляет обект сразу, не дожидаясь окончания анимации
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

    protected bool IsStun()
    {
        if (isStun)
        {
            stunTimer -= Time.deltaTime;
            if(stunTimer <= 0)
            {
                isStun = false;
                stunTimer = 0;
            }
        }

        return isStun;
    }
}


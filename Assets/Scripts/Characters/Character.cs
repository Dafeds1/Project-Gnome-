using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������������ ����� ���� �������
public class Character : MonoBehaviour
{
    public virtual bool facingRight { get; protected set; } = true;         // ��������� �� �������� � ������ �������
    [SerializeField] private float xAxesSpeed;                              // �������� ����������� �� �����������
    [SerializeField] private float groundCheckerRadius = 0.01F;             // ������ �������� ������� �����
    [SerializeField] private Transform groundChckerPos;                     // ������� ����� ��� �������� ������� �� �������� 
    [SerializeField] protected LayerMask groundMask;                        // ����� �����, ��� �������� ������� �����
    [SerializeField] protected Animator animator;                           // ������ �� ��������
    protected Rigidbody2D rb;                                               // ������ �� rigidbody

    [SerializeField] protected int maxHp;                                   // ������������ ��������
    protected int currentHp;                                                // ������� ��������

    protected float stunTimer = 0;                                          // ������ ��������� � ������� �����������
    public bool isStun { get; protected set; } = false;                     // � ����� �� ��������

    // �������������, �������� ������ �� �������� � rigidbody
    protected virtual void Initialize()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    // �������� �� �����������
    public void XAxesMove(float moveInput)
    {
        rb.velocity = new Vector2(moveInput * xAxesSpeed, rb.velocity.y);

        // ������������� ��������� ���� �������� �������� � ������ �������
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        // �������� �������� ������, ����� �������� �� �����.
        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }

    public virtual void Atack()
    {
        animator.SetTrigger("attack");
    }

    // ��������� �����, ���� ������ ����, �� ������.
    public virtual void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} � {currentHp} HP, ������� {damage} �����");// ***
        currentHp -= damage;
        animator.SetTrigger("takeDamage");
        if (currentHp <= 0)
            Die();
    }

    protected void Die()
    {
        TakeStun(300);
        animator.SetTrigger("dying");
        //GameObject.Destroy(gameObject);       //  *** ��������� ����������� ������� ����� �� ���������    ***
    }

    public void TakeStun(float stunTime)
    {
        isStun = true;
        stunTimer = stunTime;
    }

    // ����������� ���� ������ � ���������� ������, ���� �������� ������� � �����.
    public void StunTimerStap()
    {
        if (isStun)
        {
            stunTimer -= Time.deltaTime;
            if(!(stunTimer > 0))
            {
                isStun = false;
                stunTimer = 0;
            }
        }
    }

    // �������� ���������, ������ � ������� ��������.
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    // ��������, ������� �� �������.
    protected bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChckerPos.position, groundCheckerRadius, groundMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundChckerPos.position, groundCheckerRadius);
    }
}


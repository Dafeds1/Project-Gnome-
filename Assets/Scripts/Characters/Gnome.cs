using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� �����. ��������� ��� ��� ����������� + ����������, �������� �� ������������� ������
public class Gnome : Character
{
    [SerializeField] private float jumpForce;                   // ���� ������.
    [SerializeField] private float groundCheckerRadius = 0.01F;             // ������ �������� ������� �����
    [SerializeField] private Transform groundCheckerPos;                    // ������� ����� ��� �������� ������� �� �������� 
    [SerializeField] protected LayerMask groundMask;                        // ����� �����, ��� �������� ������� �����

    [SerializeField] private CollisionTester collisionTester;   // ������ �� ������, ����������� ������������, ��� �� �� ���������� � ������.
    [SerializeField] private Weapon weapon1;                    // ������ �� ������ ������, �����.
    private bool isGrounded;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        // ��������� ������������ ����� �������� �������� �����, ����� ���� �� �����
        PlayerHealthBar.instance.Initialize(maxHp);
        currentHp = maxHp;// *** ��������� �� ��������, � ����� ������� ����������   ***
        PlayerHealthBar.instance.ChangeHealth(currentHp);
    }

    private void FixedUpdate()
    {
        if (isStun)
            return;

        // �������� ������������ ���� ��� ������������ ������� � ������ ��������������� �������
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
        if (isStun)
            return;
        else
            StunTimerStap();

        IsGrounded();// ��������� ���������� ��������, �� ����� �� ��������

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            Jump();// ������� ������

        // ������� ���� ������
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        // ������� �������������� ����
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Atack2();
        }
    }

    public override void Attack()
    {
        if (weapon1.TryAttack())
            base.Attack();
    }

    private void Atack2()
    {
        animator.SetTrigger("attack2");
    }

    // �������� �������� ���� � ���������� ������� ���������� ��������
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        PlayerHealthBar.instance.ChangeHealth(currentHp);
    }

    // �������� �������, ���� �� ����� � ������ ������ ������.
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        animator.SetTrigger("takeOff");
    }

    // ��������, ������� �� �������.
    protected void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckerPos.position, groundCheckerRadius, groundMask);

        if(isGrounded)
            animator.SetBool("isJumping", false);
        else
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheckerPos.position, groundCheckerRadius);
    }
}

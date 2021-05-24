using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� �����. ��������� ��� ��� ����������� + ����������, �������� �� ������������� ������
public class Gnome : Character
{
    [SerializeField] private float jumpForce;                   // ���� ������.

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
    }

    private void FixedUpdate()
    {
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
        isGrounded = IsGrounded();// ��������� ���������� ��������, �� ����� �� ��������

        Jump();// ������� ������

        // ������� ���� ������
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();
        }

        // ������� �������������� ����
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Atack2();
        }
    }

    public override void Atack()
    {
        if (weapon1.TryAttack())
            base.Atack();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������������ ����� ���� ������, ����������� �� �����������
public class Enemy : Character
{
    public Weapon weapon;                                           // ������ �� ������
    [SerializeField] protected EnemyHealthBar healthBar;            // ������ �� ����� ��������

    // �������� ����� ���������� ����������� �� �, � �������� � �����������, ������ ������� ����� � ������...   ****

    protected override void Initialize()
    {
        // ������ ������������ ��������, ��� �������������
        currentHp = maxHp;
        healthBar.Initialize(maxHp);

        base.Initialize();
    }

    // ������� �����
    public override void Attack()
    {
        // ������� ��������� �������, ���� ���� �����������
        if (weapon.TryAttack())
            base.Attack();
    }

    // �������� �������� ����, ���� ��������, ���������� ������� ��
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        healthBar.ChangeHealth(currentHp);
    }

    protected override void Die()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(GetComponent<Rigidbody2D>());

        GetComponent<Collider2D>().enabled = false;

        healthBar.gameObject.SetActive(false);

        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;

        base.Die();
    }
}

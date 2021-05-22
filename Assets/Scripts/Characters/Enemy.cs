using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������������ ����� ���� ������, ����������� �� �����������
public class Enemy : Character
{
    [SerializeField] protected Weapon weapon;               // ������ �� ������
    [SerializeField] protected EnemyHealthBar healthBar;    // ������ �� ����� ��������

    // �������� ����� ���������� ����������� �� �, � �������� � �����������, ������ ������� ����� � ������...   ****

    protected override void Initialize()
    {
        healthBar.Initialize(maxHp);
        base.Initialize();
    }
    public override void Atack()
    {
        if (weapon.TryAttack())
            base.Atack();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.ChangeHealth(currentHp);
    }
}

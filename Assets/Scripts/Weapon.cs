using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������������ ������ ��������� ������
public class Weapon : MonoBehaviour
{
    public int damage;                  // ���������� ���������� ����� �������.
    public float cooldown;              // ����� ����������� ������.
    public int targetLayerNumber;       // ����� �������� ����, ��� �����.

    protected float cooldownTime = 0;   // ������� �������� ��������

    // ������� �����
    public bool TryAttack()
    {
        // ���� �� � �������� �� ���������� �����
        if (!IsCooldown())
        {
            Attack();
            cooldownTime = cooldown;
            return true;
        }
        else
            return false;
    }

    // �����, ��������� ������ ����� ��� ��������!
    protected virtual void Attack()
    {
    }

    // ��������, � ����������� �� ������.
    protected virtual bool IsCooldown()
    {
        return cooldownTime >= 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������������ ������ ��������� ������
public class Weapon : MonoBehaviour
{
    public int damage;                          // ���������� ���������� ����� �������.
    public float cooldown;                      // ����� ����������� ������.
    public int targetLayerNumber;               // ����� �������� ����, ��� �����.
    public bool isCooldown { get; private set;} // � ����������� �� ������

    protected float cooldownTime = 0;           // ������� �������� ��������

    // ������� �����
    public bool TryAttack()
    {
        // ���� �� � �������� �� ���������� �����
        if (!isCooldown)
        {
            Attack();
            cooldownTime = cooldown;
            isCooldown = true;
            return true;
        }
        else
            return false;
    }

    // �����, ��������� ������ ����� ��� ��������!
    protected virtual void Attack()
    {
    }

    protected void CooldownTimerStep()
    {
        if (isCooldown)
        {
            cooldownTime -= Time.deltaTime;

            // ���� ����� ���������� �������, ������� ����, ������� ��������� �����.
            if (!(cooldownTime > 0))
            {
                cooldownTime = 0;
                isCooldown = false;
            }
        }
    }
}

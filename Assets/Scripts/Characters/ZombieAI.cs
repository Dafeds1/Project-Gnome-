using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI �����, ����������� �� EnemyAI
public class ZombieAI : EnemyAI
{
    private void Awake()
    {
        Initialize();
    }
    void Update()
    {
        // ������� ���� ���������� ������, ����� ��������� � ������.
        if (angry)
        {
            if (IsAttacking())
                enemy.Attack();
            else
            {
                if (PlayerIsLeft())
                    enemy.XAxesMove(-1);
                else
                    enemy.XAxesMove(1);
            }
        }
        else
        {
            enemy.XAxesMove(0);//   *** ����� ������� � EnemyAI ��������� isMoving, ��� �� �� ���������� ������ ��� ����... ��� ��� ����� �� ������, �������� ���� ��� ���� ����� ���� ������������ ***
        }
    }

    private void FixedUpdate()
    {
        IsAngri(); // �������� �� ��������� �����
    }
}

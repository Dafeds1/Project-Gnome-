using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI ����, ����������� �� EnemyAI
public class BugAI : EnemyAI
{
    private void Awake()
    {
        Initialize();
    }
    void Update()
    {
        if (enemy.isStun)
            return;
        else
            enemy.StunTimerStap();

        // ������� ���� ���������� ������, ����� ��������� � ������.
        if (angry)
        {
            if (IsAttacking())
            {
                if (enemy.facingRight == PlayerIsLeft())
                    enemy.Flip();

                enemy.Attack();
            }
            else
            {
                if (PlayerIsLeft())
                    enemy.XAxesMove(-1);
                else
                    enemy.XAxesMove(1);

                return;
            }
        }

        enemy.XAxesMove(0);//   *** ����� ������� � EnemyAI (��� ���� � Charackter) ��������� isMoving, ��� �� �� ���������� ������ ��� ����... ��� ��� ����� �� ������, �������� ���� ��� ���� ����� ���� ������������ ***
    }

    private void FixedUpdate()
    {
        IsAngri(); // �������� �� ��������� ����
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI ������, ����������� �� EnemyAI
public class GholemAI : EnemyAI
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
            if (distanceToPlayer < atackDistance)
                enemy.Atack();
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
            enemy.XAxesMove(0);//   *** ����� ������� � EnemyAI (��� ���� � Charackter) ��������� isMoving, ��� �� �� ���������� ������ ��� ����... ��� ��� ����� �� ������, �������� ���� ��� ���� ����� ���� ������������ ***
        }
    }

    
    private void FixedUpdate()
    {
        IsAngri(); // �������� �� ��������� ����
    }
}

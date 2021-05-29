using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI Жука, наследуется от EnemyAI
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

        // Атакует если достаточно близко, иначе двигается к игроку.
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

        enemy.XAxesMove(0);//   *** нужно вывести в EnemyAI (или даже в Charackter) переменую isMoving, что бы не передовать каждый раз ноль... это это может не помочь, передать один раз ноль может быть недостаточно ***
    }

    private void FixedUpdate()
    {
        IsAngri(); // Проверка на активацию жука
    }
}

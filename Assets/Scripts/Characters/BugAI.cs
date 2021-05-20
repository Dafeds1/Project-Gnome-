using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAI : EnemyAI
{
    private void Awake()
    {
        Initialize();
    }
    void Update()
    {
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
            enemy.XAxesMove(0);//   *** нужно вывести в EnemyAI переменую isMoving, что бы не передовать каждый раз ноль... это это может не помочь, передать один раз ноль может быть недостаточно ***
        }
    }

    private void FixedUpdate()
    {
        IsAngri();
    }
}

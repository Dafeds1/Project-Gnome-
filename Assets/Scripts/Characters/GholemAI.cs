using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GholemAI : EnemyAI
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
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
                    enemy.XAxesMove(-0.5f);
                else
                    enemy.XAxesMove(0.5f);
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

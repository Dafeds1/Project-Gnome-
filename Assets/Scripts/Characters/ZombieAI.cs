using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI «омби, наследуетс€ от EnemyAI
public class ZombieAI : EnemyAI
{
    private void Awake()
    {
        Initialize();
    }
    void Update()
    {
        // јтакует если достаточно близко, иначе двигаетс€ к игроку.
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
            enemy.XAxesMove(0);//   *** нужно вывести в EnemyAI переменую isMoving, что бы не передовать каждый раз ноль... это это может не помочь, передать один раз ноль может быть недостаточно ***
        }
    }

    private void FixedUpdate()
    {
        IsAngri(); // ѕроверка на активацию зомби
    }
}

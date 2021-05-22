using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// –одительский класс всех врагов, описывающие их возможности
public class Enemy : Character
{
    [SerializeField] protected Weapon weapon;               // —сылка на оружие
    [SerializeField] protected EnemyHealthBar healthBar;    // —сылка на шкалу здоровь€

    // ¬озможно стоит переписать перемещение по ’, с разгоном и замедлением, просто выбаром влево и вправо...   ****

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

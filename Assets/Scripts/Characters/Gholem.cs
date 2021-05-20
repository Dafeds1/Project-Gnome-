using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gholem : Enemy
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private EnemyHealthBar healthBar;

    private void Awake()
    {
        healthBar.maxtHeatlh = maxHp;
        healthBar.Initialize();
        Initialize();
    }

    public override void Atack()
    {
        if (weapon.Attack())
            base.Atack();
    }

    public override void TakeDamage(int damage)
    {
        healthBar.ChangeHaelth(hp);
        base.TakeDamage(damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    [SerializeField] private EnemyHealthBar helthBar;

    private void Awake()
    {
        Initialize();
        helthBar = GetComponentInChildren<EnemyHealthBar>();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        helthBar.ChangeHaelth(hp);
    }
}

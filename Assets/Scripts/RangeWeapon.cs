using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс дальнего оружия.
public class RangeWeapon : Weapon
{
    public GameObject projectile;           // Префаб снаряда.
    public Transform projectileStartPos;    // Позиция для запуска снаряда.
    public bool facingRight;                // Направление снаряда.

    private void Update()
    {
        CooldownTimerStap();
    }

    // Атака, созадние снаряда и передача ему необходимых данных
    protected override void Attack()
    {
        GameObject go = Instantiate(projectile);
        go.transform.position = projectileStartPos.position;
        go.GetComponent<Projectile>().Initialize(facingRight);
    }
}

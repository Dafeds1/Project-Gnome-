using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс дальнего оружия.
public class RangeWeapon : Weapon
{
    public GameObject projectile;           // Префаб снаряда.
    public Transform projectileStartPos;    // Позиция для запуска снаряда.

    private Character chr;                  // Ссылка на персонажа, носителя оружия.

    private void Start()
    {
        chr = GetComponentInParent<Character>();
    }

    private void Update()
    {
        CooldownTimerStep();
    }

    // Атака, созадние снаряда и передача ему необходимых данных
    protected override void Attack()
    {
        GameObject go = Instantiate(projectile);
        go.transform.position = projectileStartPos.position;
        go.GetComponent<Projectile>().Initialize(chr.facingRight);
    }
}

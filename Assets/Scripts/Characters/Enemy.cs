using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Родительский класс всех врагов, описывающие их возможности
public class Enemy : Character
{
    public Weapon weapon;                                           // Ссылка на оружие
    [SerializeField] protected EnemyHealthBar healthBar;            // Ссылка на шкалу здоровья

    // Возможно стоит переписать перемещение по Х, с разгоном и замедлением, просто выбаром влево и вправо...   ****

    protected override void Initialize()
    {
        // Задаем максимальное здоровье, при инициализации
        currentHp = maxHp;
        healthBar.Initialize(maxHp);

        base.Initialize();
    }

    // Попытка атаки
    public override void Attack()
    {
        // Атакует имеющимся оружием, если есть возможность
        if (weapon.TryAttack())
            base.Attack();
    }

    // Персонаж получает урон, если выживает, отображаем текущие хп
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        healthBar.ChangeHealth(currentHp);
    }

    protected override void Die()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(GetComponent<Rigidbody2D>());

        GetComponent<Collider2D>().enabled = false;

        healthBar.gameObject.SetActive(false);

        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;

        base.Die();
    }
}

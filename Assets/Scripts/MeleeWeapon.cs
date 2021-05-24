using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс оружия ближнего боя.
public class MeleeWeapon : Weapon
{
    public bool isAtack;        // Аружие в атаке

    private void Update()
    {
        // Если в кулауне, сокращаем таймер кулдауна
        if (IsCooldown())
        {
            cooldown -= Time.deltaTime;

            // Если после сокращения таймера, кулдаун спал, умераем активацию атаки.
            if (!IsCooldown())
            {
                isAtack = false;
                cooldown = 0;
            }
        }
    }

    // Во время атаки, активируем атаку
    protected override void Attack()
    {
        isAtack = true;
    }

    // Если в атакующем режими в колайдер оружия попал объект с целевым слоем, наносим урон и отключаем режим атаки
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAtack && collision.gameObject.layer.Equals(targetLayerNumber))
        {
            collision.GetComponent<Character>().TakeDamage(damage);

            isAtack = false;
        }
    }
}

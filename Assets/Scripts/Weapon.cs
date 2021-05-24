using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Родительский объект вариантов оружия
public class Weapon : MonoBehaviour
{
    public int damage;                  // Количество наносимого урона оружием.
    public float cooldown;              // Время перезарядки оружия.
    public int targetLayerNumber;       // Номер целевого слоя, для урона.

    protected float cooldownTime = 0;   // Текущие значение кулдауна

    // Попытка атаки
    public bool TryAttack()
    {
        // Если не в кулдауне то активируем атаку
        if (!IsCooldown())
        {
            Attack();
            cooldownTime = cooldown;
            return true;
        }
        else
            return false;
    }

    // Атака, запускать только когда это зозможно!
    protected virtual void Attack()
    {
    }

    // Проверка, в перезарядки ли оружие.
    protected virtual bool IsCooldown()
    {
        return cooldownTime >= 0;
    }
}

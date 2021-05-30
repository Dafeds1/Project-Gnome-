using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Родительский объект вариантов оружия
public class Weapon : MonoBehaviour
{
    public int damage;                          // Количество наносимого урона оружием.
    public float cooldown;                      // Время перезарядки оружия.
    public int targetLayerNumber;               // Номер целевого слоя, для урона.
    public bool isCooldown { get; private set;} // в перезарядке ли оружие

    protected float cooldownTime = 0;           // Текущие значение кулдауна

    // Попытка атаки
    public bool TryAttack()
    {
        // Если не в кулдауне то активируем атаку
        if (!isCooldown)
        {
            Attack();
            cooldownTime = cooldown;
            isCooldown = true;
            return true;
        }
        else
            return false;
    }

    // Атака, запускать только когда это зозможно!
    protected virtual void Attack()
    {
    }

    protected void CooldownTimerStep()
    {
        if (isCooldown)
        {
            cooldownTime -= Time.deltaTime;

            // Если после сокращения таймера, кулдаун спал, умераем активацию атаки.
            if (!(cooldownTime > 0))
            {
                cooldownTime = 0;
                isCooldown = false;
            }
        }
    }
}

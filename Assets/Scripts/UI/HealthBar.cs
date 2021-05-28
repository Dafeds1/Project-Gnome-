using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Родительский класс, отвечает за отоброжение количества жизней.
public class HealthBar : MonoBehaviour
{
    [SerializeField] protected int maxHealth;   // Максимальное количество здоровья

    // Инициализация, запускаетя из вне, задает максимальное здоровье и отображает его
    public virtual void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
        ChangeHealth(maxHealth);
    }

    // Меняет отображаемое количество здоровья
    public virtual void ChangeHealth(int healthCount)
    {

    }
}

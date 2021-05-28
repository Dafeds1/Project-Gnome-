using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Отвечает за отоброжение количества жизней сцществ.
public class EnemyHealthBar : HealthBar
{
    [SerializeField] private Slider healthSlider;               // Полоска HP
    [SerializeField] private GameObject healthPointImage;       // Картинки ячеек здоровья
    [SerializeField] private Transform healthPointImageArea;    // Ссылка на родительский обект для ячеек хп

    // Меняет отображаемое количество здоровья
    public override void ChangeHealth(int healthCount)
    {
        healthSlider.value = healthCount;
    }

    // Инициализация, запускаетя из вне, задает максимальное здоровье и отображает его
    public override void Initialize(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;

        for (int i = 0; i < maxHealth - 1; i++)
        {
            GameObject go = Instantiate(healthPointImage, healthPointImageArea);
        }

        base.Initialize(maxHealth);
    }
}

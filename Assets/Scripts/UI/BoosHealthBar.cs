using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ќтвечает за отоброжение количества жизней Ѕосса.
public class BoosHealthBar : HealthBar
{
    [SerializeField] private Slider healthSlider;    // полоска HP

    // ћен€ет отображаемое количество здоровь€
    public override void ChangeHealth(int healthCount)
    {
        healthSlider.value = healthCount;
    }

    // »нициализаци€, запускает€ из вне, задает максимальное здоровье и отображает его
    public override void Initialize(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;

        base.Initialize(maxHealth);
    }
}

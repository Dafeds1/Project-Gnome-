using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �������� �� ����������� ���������� ������ �����.
public class BoosHealthBar : HealthBar
{
    [SerializeField] private Slider healthSlider;    // ������� HP

    // ������ ������������ ���������� ��������
    public override void ChangeHealth(int healthCount)
    {
        healthSlider.value = healthCount;
    }

    // �������������, ���������� �� ���, ������ ������������ �������� � ���������� ���
    public override void Initialize(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;

        base.Initialize(maxHealth);
    }
}

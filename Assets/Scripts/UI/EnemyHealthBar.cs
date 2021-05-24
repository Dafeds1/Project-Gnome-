using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �������� �� ����������� ���������� ������ �������.
public class EnemyHealthBar : HealthBar
{
    [SerializeField] private Slider healthSlider;               // ������� HP
    [SerializeField] private GameObject healthPointImage;       // �������� ����� ��������
    [SerializeField] private Transform healthPointImageArea;    // ������ �� ������������ ����� ��� ����� ��

    // ������ ������������ ���������� ��������
    public override void ChangeHealth(int healthCount)
    {
        healthSlider.value = healthCount;
    }

    // �������������, ���������� �� ���, ������ ������������ �������� � ���������� ���
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

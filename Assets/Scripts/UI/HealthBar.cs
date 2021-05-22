using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ������������ �����, �������� �� ����������� ���������� ������.
public class HealthBar : MonoBehaviour
{
    [SerializeField] protected int maxHealth;   // ������������ ���������� ��������

    // �������������, ���������� �� ���, ������ ������������ �������� � ���������� ���
    public virtual void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
        ChangeHealth(maxHealth);
    }

    // ������ ������������ ���������� ��������
    public virtual void ChangeHealth(int healthCount)
    {

    }
}

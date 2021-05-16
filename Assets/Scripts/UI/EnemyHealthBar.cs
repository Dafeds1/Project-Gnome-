using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private int maxtHeatlh = 5;
    [SerializeField] private Slider healths;    // ������� HP

    private void Start()
    {
        healths.maxValue = maxtHeatlh;
        ChangeHaelth(maxtHeatlh);   // *** ����� ��? ��� ����� �������� �������� ���������� ��������, ��� ������ �����? ***
    }

    // ������ ������������ ���������� ��������
    public void ChangeHaelth(int healthCount)
    {
        healths.value = healthCount;
    }
}

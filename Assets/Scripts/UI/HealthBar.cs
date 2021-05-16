using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �������� �� ����������� ���������� ������.
//  *** �������� ����� ������� ����������� ***
public class HealthBar : MonoBehaviour
{
    private int maxtHeatlh = 5;
    [SerializeField] private Image[] healths;   // ������ ������ �� �������� ��������
    [SerializeField] private Sprite healthOn;   // �������� ���� ��������
    [SerializeField] private Sprite healthOff;  // �������� �������������� ��������

    public static HealthBar instance;

    private void Start()
    {
        ChangeHaelth(maxtHeatlh);   // *** ����� ��? ��� ����� �������� �������� ���������� ��������, ��� ������ �����? ***

        instance = this;
    }

    // ������ ������������ ���������� ��������
    public void ChangeHaelth(int healthCount)
    {
        for(int i = 0; i < maxtHeatlh;i++)
        {
            if (i < healthCount)
                healths[i].sprite = healthOn;
            else
                healths[i].sprite = healthOff;
        }
    }
}

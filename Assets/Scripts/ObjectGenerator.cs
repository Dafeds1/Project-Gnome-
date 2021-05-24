using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� ���������, ������� ������ ������ �� �������
public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private float timeInterval;            // �������� ���������
    [SerializeField] private GameObject generatedObject;    // ������������ ������

    private float currentTimer;                             // ������� ��������� ������� ��������� ���������

    // ����������� ������ �� ����, ��������� ������ � ��������� ������ �����.
    private void Update()
    {
        currentTimer -= Time.deltaTime;

        if (currentTimer < 0)
        {
            currentTimer = timeInterval;
            Generate();
        }
    }

    // ��������� �������, � ���������� � ��������� �������� ������
    private void Generate()
    {
        Instantiate(generatedObject,transform.position,transform.rotation);
    }
}

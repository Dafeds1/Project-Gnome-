using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �������� �� ����������� ���������� ������ ��.
public class PlayerHealthBar : HealthBar
{
    [SerializeField] private List<Image> healths;   // ������ ������ �� �������� ��������
    [SerializeField] private Sprite healthOn;       // �������� ���� ��������
    [SerializeField] private Sprite healthOff;      // �������� �������������� ��������

    public static PlayerHealthBar instance;         // ��������

    private void Awake()
    {
        // ���� �������� � ���� �������� ������ ������, ����������
        if (instance)
            GameObject.Destroy(gameObject);
        else
            instance = this;
    }

    public override void Initialize(int maxHealth)
    {
        // ������� �������� ��� ����������� ��(���������� ������� �� ���� ��)� �������� �� ��� ������ � ������.
        healths = new List<Image>();
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject go = new GameObject();
            go.transform.SetParent(transform);
            healths.Add(go.AddComponent<Image>());
        }

        base.Initialize(maxHealth);
    }

    // ������ ������������ ���������� ��������
    public override void ChangeHealth(int healthCount)
    {
        for (int i = 0; i < healths.Count; i++)
        {
            if (i < healthCount)
                healths[i].sprite = healthOn;
            else
                healths[i].sprite = healthOff;
        }
    }
}

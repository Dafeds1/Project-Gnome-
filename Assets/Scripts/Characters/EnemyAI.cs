using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������������ ����� AI ���� ������.
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float angryDistance;           // ��������� ���������, ����������� ����.
    [SerializeField] protected float atackDistance;         // ��������� �� ������� ��� �������� ���������.

    private bool visible;                                   // ����� �� ��� � ������.
    protected bool angry;                                   // ������ �� ���, ������� �� ������.
    protected float distanceToPlayer;                       // ��������� �� ������.
    protected Enemy enemy;                                  // ������ �� ���������, ������� ��������� ������ ��
    private Transform player;                               // ������ �� ��������� ������

    // ������������, �������� ������
    protected void Initialize()
    {
        enemy = GetComponent<Enemy>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // ���������� ��������� ��������, ������������� �� ���
    // ������������, ���� ����� ���������� ������ � ��� � ������
    protected bool IsAngri()
    {
        distanceToPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceToPlayer < angryDistance && visible)
        {
            angry = true;
        }
        else
        {
            angry = false;
        }

        return angry;
    }

    // �������� � ����� ������� �����, �� ����
    protected bool PlayerIsLeft()
    {
        if (player.position.x - transform.position.x < 0)
            return true;
        else
            return false;
    }

    // �������� �� ��������� ���� � ������
    private void OnBecameVisible()
    {
        visible = true;
    }

    private void OnBecameInvisible()
    {
        visible = false;
    }
}

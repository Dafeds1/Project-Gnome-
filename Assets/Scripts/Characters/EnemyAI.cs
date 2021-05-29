using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������������ ����� AI ���� ������.
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float angryDistance;           // ��������� ���������, ����������� ����.
    [SerializeField] protected float attackDistance;         // ��������� �� ������� ��� �������� ���������.

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

        if (visible && distanceToPlayer < angryDistance)
        {
            angry = true;
        }
        else
        {
            angry = false;
        }

        return angry;
    }

    protected bool IsAttacking()
    {
        float weaponDistanceToPlayer = Vector2.Distance(player.position, enemy.weapon.transform.position);

        if (angry && weaponDistanceToPlayer < attackDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
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

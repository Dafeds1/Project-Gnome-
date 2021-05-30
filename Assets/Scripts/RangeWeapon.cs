using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� �������� ������.
public class RangeWeapon : Weapon
{
    public GameObject projectile;           // ������ �������.
    public Transform projectileStartPos;    // ������� ��� ������� �������.

    private Character chr;                  // ������ �� ���������, �������� ������.

    private void Start()
    {
        chr = GetComponentInParent<Character>();
    }

    private void Update()
    {
        CooldownTimerStep();
    }

    // �����, �������� ������� � �������� ��� ����������� ������
    protected override void Attack()
    {
        GameObject go = Instantiate(projectile);
        go.transform.position = projectileStartPos.position;
        go.GetComponent<Projectile>().Initialize(chr.facingRight);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    public GameObject projectile;
    public Transform projectileStartPos;
    public bool facingRight;

    protected override void Attack()
    {
        GameObject go = Instantiate(projectile);
        go.transform.position = projectileStartPos.position;
        go.GetComponent<Projectile>().Initialize(facingRight);
    }
}

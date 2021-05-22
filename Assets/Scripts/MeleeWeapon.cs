using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public bool isAtack;

    private void Update()
    {
        if (IsCooldown())
        {
            cooldown -= Time.deltaTime;

            if (!IsCooldown())
            {
                isAtack = false;
                cooldown = 0;
            }
        }
    }

    protected override void Attack()
    {
        isAtack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAtack && collision.gameObject.layer.Equals(targetLayerNumber))
        {
            collision.GetComponent<Character>().TakeDamage(damage);

            isAtack = false;
        }
    }
}

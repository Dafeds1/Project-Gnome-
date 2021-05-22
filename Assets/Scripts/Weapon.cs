using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float cooldownTime;
    public int targetLayerNumber;

    protected float cooldown = 0;

    public bool TryAttack()
    {
        if (!IsCooldown())
        {
            Attack();
            cooldown = cooldownTime;
            return true;
        }
        else
            return false;
    }

    protected virtual void Attack()
    {
    }

    protected virtual bool IsCooldown()
    {
        return cooldown > 0;
    }
}

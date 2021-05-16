using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float cooldownTime;
    public bool isAtack;
    public int targetLayerNumber;

    private float cooldown = 0;

    private void Update()
    {
        if (IsCooldown())
        {
            cooldown -= Time.deltaTime;

            if (!IsCooldown())
                isAtack = false;
        }
    }

    public bool Attack()
    {
        if (!IsCooldown())
        {
            isAtack = true;
            cooldown = cooldownTime;
            return true;
        }
        else
            return false;
    }

    private bool IsCooldown()
    {
        return cooldown > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAtack && collision.gameObject.layer.Equals(targetLayerNumber))
        {
            Debug.Log("попал в "+collision.gameObject.name);
            collision.GetComponent<Character>().TakeDamage(damage);

            isAtack = false;
        }
    }
}

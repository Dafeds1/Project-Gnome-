using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : Enemy
{
    [SerializeField] private EnemyHealthBar healthBar;// *** нужно вывести в Enemy ***
    public GameObject projectile; 
    public Transform projectileStartPos; 

    private void Awake()
    {
        healthBar.maxtHeatlh = maxHp;
        healthBar.Initialize();
        Initialize();
    }

    public override void Atack()
    {
        base.Atack();

        GameObject go = Instantiate(projectile);
        go.transform.position = projectileStartPos.position;
        go.GetComponent<Projectile>().facingRight = facingRight;
        go.GetComponent<Projectile>().Initialize();
    }

    public override void TakeDamage(int damage)
    {
        healthBar.ChangeHaelth(hp);// *** нужно вывести в Enemy ***
        base.TakeDamage(damage);
    }
}

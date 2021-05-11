using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  *** нужен енум side{ enemy ally neutral}
// корневой класс всех существ
namespace Characters
{
    public class Character : MonoBehaviour
    {
        string name;
        int maxHp;
        int hp;

        private Animator animator;

        public Character(string name, int maxHp)
        {
            this.name = name;
            this.maxHp = maxHp;

            Initialize();
        }

        public void Initialize()
        {
            hp = maxHp;
            animator = GetComponent<Animator>();
        }

        public void Atack()
        {

        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
                Die();
        }

        public void Die()
        {

        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// √лавный герой. описывает все его возможности + управление, отличные от родительского класса
public class Gnome : Character
{
    [SerializeField] private float jumpForce;                   // —ила прыжка.

    [SerializeField] private CollisionTester collisionTester;   // —сылка на объект, провер€ющий столкнавени€, что бы не застривать в полете.
    [SerializeField] private Weapon weapon1;                    // —сылка на первое оружие, кирка.
    private bool isGrounded;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        // заполн€ем персональную шкалу здоровь€ главного геро€, така€ одна на сцене
        PlayerHealthBar.instance.Initialize(maxHp);
    }

    private void FixedUpdate()
    {
        // персонаж перемещаетс€ если нет столкнавени€ вполете и нажаты соответствуеюие калвиши
        if (!isGrounded && collisionTester.collisionCount >= 1)
        {
            XAxesMove(0);
        }
        else
        {
            XAxesMove(Input.GetAxis("Horizontal"));
        }
    }

    private void Update()
    {
        isGrounded = IsGrounded();// обновл€ем переменную проверки, на замле ли персонаж

        Jump();// попытка прыжка

        // попытка атак киркой
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();
        }

        // попытка дополнительной атак
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Atack2();
        }
    }

    public override void Atack()
    {
        if (weapon1.TryAttack())
            base.Atack();
    }

    private void Atack2()
    {
        animator.SetTrigger("attack2");
    }

    // ѕерсонаж получает урон и отображаем текущее количество здоровь€
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        PlayerHealthBar.instance.ChangeHealth(currentHp);
    }

    // ѕерсонаж прыгает, если на земле и нажата кнопка прыжка.
    private void Jump()
    {
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetTrigger("takeOff");
            }
        }
        else
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
    }
}

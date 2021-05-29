using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Главный герой. описывает все его возможности + управление, отличные от родительского класса
public class Gnome : Character
{
    [SerializeField] private float jumpForce;                   // Сила прыжка.
    [SerializeField] private float groundCheckerRadius = 0.01F;             // Радиус проверки касания земли
    [SerializeField] private Transform groundCheckerPos;                    // Позиция крука для проверки наземле ли персонаж 
    [SerializeField] protected LayerMask groundMask;                        // Маска слове, для проверки касания земли

    [SerializeField] private CollisionTester collisionTester;   // Ссылка на объект, проверяющий столкнавения, что бы не застривать в полете.
    [SerializeField] private Weapon weapon1;                    // Ссылка на первое оружие, кирка.
    private bool isGrounded;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        // заполняем персональную шкалу здоровья главного героя, такая одна на сцене
        PlayerHealthBar.instance.Initialize(maxHp);
        currentHp = maxHp;// *** исправить на загрузку, в место полного заполнения   ***
        PlayerHealthBar.instance.ChangeHealth(currentHp);
    }

    private void FixedUpdate()
    {
        if (isStun)
            return;

        // персонаж перемещается если нет столкнавения вполете и нажаты соответствуеюие калвиши
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
        if (isStun)
            return;
        else
            StunTimerStap();

        IsGrounded();// обновляем переменную проверки, на замле ли персонаж

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            Jump();// попытка прыжка

        // попытка атак киркой
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        // попытка дополнительной атак
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Atack2();
        }
    }

    public override void Attack()
    {
        if (weapon1.TryAttack())
            base.Attack();
    }

    private void Atack2()
    {
        animator.SetTrigger("attack2");
    }

    // Персонаж получает урон и отображаем текущее количество здоровья
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        PlayerHealthBar.instance.ChangeHealth(currentHp);
    }

    // Персонаж прыгает, если на земле и нажата кнопка прыжка.
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        animator.SetTrigger("takeOff");
    }

    // Проверка, наземле ли песонаж.
    protected void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckerPos.position, groundCheckerRadius, groundMask);

        if(isGrounded)
            animator.SetBool("isJumping", false);
        else
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheckerPos.position, groundCheckerRadius);
    }
}

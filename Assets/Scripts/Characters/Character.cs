using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Родительский класс всех существ
public class Character : MonoBehaviour
{
    public virtual bool facingRight { get; protected set; } = true;         // Развернут ли персонаж в правую сторону
    [SerializeField] private float xAxesSpeed;                              // Скорость перемещения по горизонтали

    [SerializeField] protected Animator animator;                           // Ссылка на аниматор
    protected Rigidbody2D rb;                                               // Ссылка на rigidbody

    [SerializeField] protected int maxHp;                                   // Максимульное здоровье
    protected int currentHp;                                                // Текущие здоровье

    protected float stunTimer = 0;                                          // Таймер оглушения и процего бездействия
    public bool isStun { get; protected set; } = false;                     // В стане ли персонаж

    // Инициализация, получаем ссылки на аниматор и rigidbody
    protected virtual void Initialize()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Движение по горезонтали
    public void XAxesMove(float moveInput)
    {
        rb.velocity = new Vector2(moveInput * xAxesSpeed, rb.velocity.y);

        // Разворачиваем персонажа если начинает движение в другую сторону
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        // Включаем анимацию ходьбы, когда движемся по земле.
        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }

    public virtual void Attack()
    {
        animator.SetTrigger("attack");
    }

    // Получение урона, если жизней ноль, то смерть.
    public virtual void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} с {currentHp} HP, получил {damage} урона");// ***
        currentHp -= damage;
        animator.SetTrigger("takeDamage");
        if (currentHp <= 0)
            Die();
    }

    protected virtual void Die()
    {
        TakeStun(300);
        animator.SetTrigger("dying");
        //GameObject.Destroy(gameObject);       //  *** запускать уничтожение объекта нужно из аниматора    ***
    }

    public void TakeStun(float stunTime)
    {
        isStun = true;
        stunTimer = stunTime;
    }

    // Отсчитывает стан таймер и возвращает правду, если персонаж остался в стане.
    public void StunTimerStap()
    {
        if (isStun)
        {
            stunTimer -= Time.deltaTime;
            if(!(stunTimer > 0))
            {
                isStun = false;
                stunTimer = 0;
            }
        }
    }

    // Разворот персонажа, обычно в сторону движения.
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}


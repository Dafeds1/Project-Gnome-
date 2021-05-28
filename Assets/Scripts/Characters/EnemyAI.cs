using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Родительский класс AI всех врагов.
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float angryDistance;           // Дистанция активации, привлечения моба.
    [SerializeField] protected float atackDistance;         // Дистанция на которой моб начинает атаковать.

    private bool visible;                                   // Попал ли моб в камеру.
    protected bool angry;                                   // Актвен ли моб, заметил ли игрока.
    protected float distanceToPlayer;                       // Растояние до игрока.
    protected Enemy enemy;                                  // Ссылка на персонажа, которым управляет данный ИИ
    private Transform player;                               // Ссылка на трансформ игрока

    // Иницализация, получаем ссылки
    protected void Initialize()
    {
        enemy = GetComponent<Enemy>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Возвращает результат проверки, активировался ли моб
    // Активируется, если игрок достаточно близко и моб в камере
    protected bool IsAngri()
    {
        distanceToPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceToPlayer < angryDistance && visible)
        {
            angry = true;
        }
        else
        {
            angry = false;
        }

        return angry;
    }

    // Проверка с какой стороны игрок, от моба
    protected bool PlayerIsLeft()
    {
        if (player.position.x - transform.position.x < 0)
            return true;
        else
            return false;
    }

    // Проверки на попадения моба в камеру
    private void OnBecameVisible()
    {
        visible = true;
    }

    private void OnBecameInvisible()
    {
        visible = false;
    }
}

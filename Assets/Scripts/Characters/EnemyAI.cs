using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Родительский класс AI всех врагов
public class EnemyAI : MonoBehaviour
{
    public float angryDistance;
    public float atackDistance;

    protected bool visible;
    protected bool angry;
    protected float distanceToPlayer;
    private Transform player;

    protected void Initialize()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

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

    protected bool PlayerIsLeft()
    {
        if (player.position.x - transform.position.x < 0)
            return true;
        else
            return false;
    }

    private void OnBecameVisible()
    {
        visible = true;
    }

    private void OnBecameInvisible()
    {
        visible = false;
    }
}

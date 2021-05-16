using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    public int collisionCount { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount--;
    }
}

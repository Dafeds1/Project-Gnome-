using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объект, проверяющий столкнавения, что бы ГГ не застривать в полете.
public class CollisionTester : MonoBehaviour
{
    public int collisionCount { get; private set; } // Счетчик объектов, с которыми происходит сталкновение в данный момент

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount--;
    }
}

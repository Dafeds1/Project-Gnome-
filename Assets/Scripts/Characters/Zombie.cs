using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс описывает все возожности Зомби, отличные от родительского класса
public class Zombie : Enemy
{
    private void Awake()
    {
        Initialize();
    }
}

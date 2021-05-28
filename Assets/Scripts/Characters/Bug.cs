using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс описывает все возожности Жук, отличные от родительского класса
public class Bug : Enemy
{
    private void Awake()
    {
        Initialize();
    }
}

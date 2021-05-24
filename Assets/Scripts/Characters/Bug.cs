using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс описывает все возожности Жук, отличные от родительского класса
public class Bug : Enemy
{
    // ***  Гдето тут глюк. жук не может развернутся назад.. дрыгается  ***
    private bool _facingRight;

    // копируем данные направления/поворота жука в переменную, которую передадим снаряду.
    public override bool facingRight {
        protected set
        {
            _facingRight = value;
        } 
    }

    private void Awake()
    {
        Initialize();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� ��������� ��� ���������� ���
public class Bug : Enemy
{
    private bool _facingRight;

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

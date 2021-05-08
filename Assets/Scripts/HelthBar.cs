using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Отвечает за отоброжение количества жизней.
//  *** возможно стоит сделать статическим ***
public class HelthBar : MonoBehaviour
{
    private int cuurentHetlh;
    [SerializeField]private Image[] haelths;
    [SerializeField] private Sprite haelthOn;
    [SerializeField] private Sprite haelthOff;

    public void ChangeHaelth(int healthCount)
    {

    }
}

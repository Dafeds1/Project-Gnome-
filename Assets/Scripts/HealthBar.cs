using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ќтвечает за отоброжение количества жизней.
//  *** возможно стоит сделать статическим ***
public class HealthBar : MonoBehaviour
{
    private int maxtHeatlh = 5;
    [SerializeField] private Image[] healths;   // ћассив ссылак на картинки здоровь€
    [SerializeField] private Sprite healthOn;   //  артинка очка здоровь€
    [SerializeField] private Sprite healthOff;  //  артинка отсутствующего здоровь€

    private void Start()
    {
        ChangeHaelth(maxtHeatlh);   // *** Ќужно ли? где будет загрузка текущего количества здоровь€, при старте сцены? ***
    }

    // ћен€ет отображаемое количество здоровь€
    public void ChangeHaelth(int healthCount)
    {
        for(int i = 0; i < maxtHeatlh;i++)
        {
            if (i < healthCount)
                healths[i].sprite = healthOn;
            else
                healths[i].sprite = healthOff;
        }
    }
}

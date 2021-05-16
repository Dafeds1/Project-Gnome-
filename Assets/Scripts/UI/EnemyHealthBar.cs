using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private int maxtHeatlh = 5;
    [SerializeField] private Slider healths;    // полоска HP

    private void Start()
    {
        healths.maxValue = maxtHeatlh;
        ChangeHaelth(maxtHeatlh);   // *** Ќужно ли? где будет загрузка текущего количества здоровь€, при старте сцены? ***
    }

    // ћен€ет отображаемое количество здоровь€
    public void ChangeHaelth(int healthCount)
    {
        healths.value = healthCount;
    }
}

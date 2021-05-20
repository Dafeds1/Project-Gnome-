using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public int maxtHeatlh = 5;
    [SerializeField] private Slider healths;    // полоска HP
    [SerializeField] private GameObject healthPointImage;
    [SerializeField] private Transform healthPointImageArea;

    // ћен€ет отображаемое количество здоровь€
    public void ChangeHaelth(int healthCount)
    {
        healths.value = healthCount;
    }

    public void Initialize()
    {
        for (int i = 0; i < maxtHeatlh - 1; i++)
        {
            GameObject go = Instantiate(healthPointImage, healthPointImageArea);
        }

        healths.maxValue = maxtHeatlh;
        ChangeHaelth(maxtHeatlh);   // *** Ќужно ли? где будет загрузка текущего количества здоровь€, при старте сцены? ***
    }
}

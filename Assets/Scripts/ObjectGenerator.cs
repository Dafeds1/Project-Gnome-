using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс генератор, создает занный префаб по таймеру
public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private float timeInterval;            // Интервал генерации
    [SerializeField] private GameObject generatedObject;    // Генерируемый префаб

    private float currentTimer;                             // Текущие состояния щетчика интервала генерации

    // Отсчитываем таймер до нуля, генерирем объект и запускаем таймер снова.
    private void Update()
    {
        currentTimer -= Time.deltaTime;

        if (currentTimer < 0)
        {
            currentTimer = timeInterval;
            Generate();
        }
    }

    // Генерация прифаба, с положением и поворотом текущего обекта
    private void Generate()
    {
        Instantiate(generatedObject,transform.position,transform.rotation);
    }
}

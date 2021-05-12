using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Границы
    public float leftLimit = -10f;
    public float rightLimit = 10f;
    public float bottomLimit = -5;
    public float upperLimit = 5;

    public float dumping = 1.5f;                    // Сила смягчения движения
    public Vector2 offset = new Vector2(2f, 3f);    // Смещение центра камеры от игрока
    public bool isLeft;                             // Персонаж повернут в лево
    private Transform player;                       // Трансформ игрока

    //  *** возможно, направление движения игрока, проще взять из скрипта управления Гнома    ***
    private float lastX;                            // Предидущие значение по X игрока
    private float currentX;                         // Текущие значение по X игрока

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        transform.position = new Vector3(player.position.x,transform.position.y,transform.position.z);
    }

    private void Update()
    {
        if (player)
        {
            // Определяем в какую сторону идет игрок
            currentX = player.position.x;
            if (currentX > lastX)
                isLeft = false;
            else if (currentX < lastX)
                isLeft = true;
            lastX = currentX;

            // Расчитываем куда должна сдвинутся камера с учетом отступа и направления движения
            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            // Здвигаем камеру к вычесленной целевой позиции. Сбавляя скорость по мере приблежения к целевой позиции
            transform.position = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
        }

        // непозволяем камере выйти за границы
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z);
    }

    // Ресуем гизмо границ за которые цент камеры не выйдет
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
    }
}

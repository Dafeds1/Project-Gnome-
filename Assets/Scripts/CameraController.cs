using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // √раницы
    public float leftLimit = -10f;
    public float rightLimit = 10f;
    public float bottomLimit = -5;
    public float upperLimit = 5;

    public float dumping = 1.5f;                    // —ила см€гчени€ движени€
    public Vector2 offset = new Vector2(2f, 3f);    // —мещение центра камеры от игрока
    private Transform playerTransform;              // “рансформ игрока
    private Gnome player;                           // —сылка на игрока

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y,transform.position.z);
        player = playerTransform.GetComponent<Gnome>();
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // –асчитываем куда должна сдвинутс€ камера с учетом отступа и направлени€ движени€
            Vector3 target;
            if (player.facingRight)
            {
                target = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(playerTransform.position.x - offset.x, playerTransform.position.y + offset.y, transform.position.z);
            }

            // «двигаем камеру к вычесленной целевой позиции. —бавл€€ скорость по мере приблежени€ к целевой позиции
            transform.position = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
        }

        // непозвол€ем камере выйти за границы
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z);
    }

    // –есуем гизмо границ за которые цент камеры не выйдет
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
    }
}

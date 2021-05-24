using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �������
    public float leftLimit = -10f;
    public float rightLimit = 10f;
    public float bottomLimit = -5;
    public float upperLimit = 5;

    public float dumping = 1.5f;                    // ���� ��������� ��������
    public Vector2 offset = new Vector2(2f, 3f);    // �������� ������ ������ �� ������
    private Transform playerTransform;              // ��������� ������
    private Gnome player;                           // ������ �� ������

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
            // ����������� ���� ������ ��������� ������ � ������ ������� � ����������� ��������
            Vector3 target;
            if (player.facingRight)
            {
                target = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(playerTransform.position.x - offset.x, playerTransform.position.y + offset.y, transform.position.z);
            }

            // �������� ������ � ����������� ������� �������. ������� �������� �� ���� ����������� � ������� �������
            transform.position = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
        }

        // ����������� ������ ����� �� �������
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z);
    }

    // ������ ����� ������ �� ������� ���� ������ �� ������
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
    }
}

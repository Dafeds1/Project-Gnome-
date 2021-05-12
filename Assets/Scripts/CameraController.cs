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
    public bool isLeft;                             // �������� �������� � ����
    private Transform player;                       // ��������� ������

    //  *** ��������, ����������� �������� ������, ����� ����� �� ������� ���������� �����    ***
    private float lastX;                            // ���������� �������� �� X ������
    private float currentX;                         // ������� �������� �� X ������

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        transform.position = new Vector3(player.position.x,transform.position.y,transform.position.z);
    }

    private void Update()
    {
        if (player)
        {
            // ���������� � ����� ������� ���� �����
            currentX = player.position.x;
            if (currentX > lastX)
                isLeft = false;
            else if (currentX < lastX)
                isLeft = true;
            lastX = currentX;

            // ����������� ���� ������ ��������� ������ � ������ ������� � ����������� ��������
            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
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

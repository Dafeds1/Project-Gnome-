using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��� ������ �������� ������, RangeWeapon.
public class Projectile : MonoBehaviour
{
    [SerializeField] public int damage;             // ���� ������� ������� ������.
    [SerializeField] public float projectileSpeed;  // �������� �������.
    [SerializeField] public float lifetime;         // ����� ����� �������.
    [SerializeField] public int targetLayerNumber;  // ����� ���� ����.

    // �������������
    // � ���������� �� ����������� ��������, ������������� �������� ������� ��� �������� ����������� ������ �������
    public void Initialize(bool facingRight)
    { 
        if (facingRight)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        else
        {
            projectileSpeed *= -1;
        }
    }

    // ���� ����� ����� ������� �������, ������� ���
    // �����, ������ ���������� ������.
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0) DestroyProjectile();

        transform.position = new Vector3(transform.position.x + projectileSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    // ���� ������ �������� � ����� � ������� ����� ��, ��������� ���� � ������ ���������.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(targetLayerNumber))
        {
            collision.GetComponent<Character>().TakeDamage(damage);

            DestroyProjectile();
        }
    }

    // ����������� �������
    //  ***  ����� �������� ��������, ��� �������� ����� �������� ���� �����, ��� ��� ����� ���������� �����������   ***
    private void DestroyProjectile()
    {
        GameObject.Destroy(gameObject);
    }
}

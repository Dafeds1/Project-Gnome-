using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Снаряд для класса дальнего оружия, RangeWeapon.
public class Projectile : MonoBehaviour
{
    [SerializeField] public int damage;             // Урон который наносит снаряд.
    [SerializeField] public float projectileSpeed;  // Скорость снаряда.
    [SerializeField] public float lifetime;         // Время жизни снаряда.
    [SerializeField] public int targetLayerNumber;  // Номер слоя цели.

    // Инициализация
    // В зависимоси от направления выстрела, разворачиваем картинку снаряда или изменяем направление полета снаряда
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

    // Если время жизни снаряда истекло, удаляем его
    // иначе, снаряд продолжает лететь.
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0) DestroyProjectile();

        transform.position = new Vector3(transform.position.x + projectileSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    // Если сняряд попадает в обект с целевым слоем то, наносится урон и снаряд удаляется.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(targetLayerNumber))
        {
            collision.GetComponent<Character>().TakeDamage(damage);

            DestroyProjectile();
        }
    }

    // Уничтожение снаряда
    //  ***  нужно добавить анимацию, или анимация будет выхывать этот метот, или тут будут запускатся спецэффекты   ***
    private void DestroyProjectile()
    {
        GameObject.Destroy(gameObject);
    }
}

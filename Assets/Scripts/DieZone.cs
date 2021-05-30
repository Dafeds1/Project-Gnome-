using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour
{
    public int damage;

    [SerializeField] private Transform restartPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character chr = collision.GetComponent<Character>();
        if (chr != null)
        {
            chr.TakeDamage(damage);

            chr.TakeStun(0.5f);

            chr.transform.position = restartPos.position;
        }
    }

    private void OnDrawGizmos()
    {
        BoxCollider2D boxcollider = GetComponent<BoxCollider2D>();
        float leftLimit = transform.position.x - (boxcollider.size.x/2);
        float rightLimit = transform.position.x + (boxcollider.size.x/2);
        float upperLimit = transform.position.y + (boxcollider.size.y/2);
        float bottomLimit = transform.position.y - (boxcollider.size.y/2);

        Gizmos.color = Color.gray;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
    }
}

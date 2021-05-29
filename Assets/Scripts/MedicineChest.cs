using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    public int healthingPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gnome chr = collision.GetComponent<Gnome>();
        if (chr != null)
        {
            chr.Healthing(healthingPoints);
            GameObject.Destroy(gameObject);
        }
    }
}

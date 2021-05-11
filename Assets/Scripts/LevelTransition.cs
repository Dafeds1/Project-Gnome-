using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Переход межу уровнями
public class LevelTransition : MonoBehaviour
{
    [SerializeField] private string targetLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Saver.instance.currentLavel = targetLevel;
            Saver.instance.Save();
            SceneTransition.SwitchToScene(targetLevel);
        }
    }
}

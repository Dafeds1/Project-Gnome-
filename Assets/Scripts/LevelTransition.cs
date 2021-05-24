using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Переход межу уровнями, используя класс SceneTransition
public class LevelTransition : MonoBehaviour
{
    [SerializeField] private string targetLevel;        // Ссылка на класс отвечающий за загрузки сцен

    // При входе Игрока в тригер, загрузается заданная сцена
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

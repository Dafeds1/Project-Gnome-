using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Меню Паузы
//  *** нужно добавить чекбокс вкл/выкл звук    ***
//  *** время не идет, но нажатые кнопки задействуются после выхода из паузы    ***
// для анемированного меню нужно выбрать Unscaled Time, Update Mode в Аниматоре, что бы на него не действовала остоновка времени !!!
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;                // В паузе или нет

    [SerializeField] private GameObject pauseMenuUI;        // Ссылка на меню паузы
    [SerializeField] private GameObject deathMenuUI;        // Ссылка на меню смерти

    public static PauseMenu instance;                       // Синглтон

    private void Awake()
    {
        // если объектов с этим скриптом больее одного, уничтожаем
        if (instance)
            GameObject.Destroy(gameObject);
        else
            instance = this;
    }

    private void Update()
    {
        // Вкл/выкл паузы по ескейпу
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Возврат из паузы
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    // вкл/выкл звук
    //  *** не реализован   ***
    public void SwitchSound()
    {
        // Добавить вкл/выкл звука  ***
    }

    // Переход в стартовое меню
    public void StartMenu() 
    {
        Time.timeScale = 1;
        SceneTransition.SwitchToScene("StartMenu");
    }

    // Выход из игры
    public void QuitGame()
    {
        Application.Quit();
    }

    // Переход в паузу
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Die()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0.5f;
    }
}

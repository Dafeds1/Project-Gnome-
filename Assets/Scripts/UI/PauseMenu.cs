using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Меню Паузы
//  *** нужно добавить чекбокс вкл/выкл звук    ***
//  *** время не идет, но нажатые кнопки задействуются после выхода из паузы    ***
// для анемированного меню нужно выбрать Unscaled Time, Update Mode в Аниматоре, что бы на него не действовала остоновка времени !!!
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
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

    // возврат из паузы
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
        SceneTransition.SwitchToScene("LevelStart");
    }

    // выход из игры
    public void QuitGame()
    {
        Application.Quit();
    }

    // переход в паузу
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
}

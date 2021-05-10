using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Главное меню на стартовой сцене
public class StartMenu : MonoBehaviour
{
    // Запуск первого уровня
    public void NewGame()
    {
        Saver.instance.ResetProgress();
        SceneTransition.SwitchToScene("Level1");
    }

    // Продложить с сохранения
    public void ContinueGame()
    {
        SceneTransition.SwitchToScene(Saver.instance.currentLavel);
    }

    // Выход из игры
    public void QuitGame()
    {
        Application.Quit();
    }
}

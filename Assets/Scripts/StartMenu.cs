using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// √лавное меню на стартовой сцене
public class StartMenu : MonoBehaviour
{
    // «апуск первого уровн€
    public void NewGame()
    {
        // ***  тут нужно добавить сохранени€ изначальных параметров    ***
        SceneTransition.SwitchToScene("Level1");
    }

    // ѕродложить с сохранени€  *** не реализован   ***
    public void ContinueGame()
    {
        // проверка есть ли сохранение
        // загрузка и переход на текущий уровень игрока
    }

    // ¬ыход из игры
    public void QuitGame()
    {
        Application.Quit();
    }
}

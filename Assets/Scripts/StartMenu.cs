using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneTransition.SwitchToScene("Level1");
    }

    public void ContinueGame()
    {

    }

    public void SelectLevel()
    {

    }

    // ����� �� ����
    public void QuitGame()
    {
        Application.Quit();
    }
}

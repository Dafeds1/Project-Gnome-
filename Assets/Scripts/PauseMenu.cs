using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �����
//  *** ����� �������� ������� ���/���� ����    ***
//  *** ����� �� ����, �� ������� ������ ������������� ����� ������ �� �����    ***
// ��� �������������� ���� ����� ������� Unscaled Time, Update Mode � ���������, ��� �� �� ���� �� ����������� ��������� ������� !!!
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    private void Update()
    {
        // ���/���� ����� �� �������
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

    // ������� �� �����
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    // ���/���� ����
    //  *** �� ����������   ***
    public void SwitchSound()
    {
        // �������� ���/���� �����  ***
    }

    // ������� � ��������� ����
    public void StartMenu() 
    {
        Time.timeScale = 1;
        SceneTransition.SwitchToScene("LevelStart");
    }

    // ����� �� ����
    public void QuitGame()
    {
        Application.Quit();
    }

    // ������� � �����
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
}

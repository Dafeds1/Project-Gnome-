using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �����
//  *** ����� �������� ������� ���/���� ����    ***
//  *** ����� �� ����, �� ������� ������ ������������� ����� ������ �� �����    ***
// ��� �������������� ���� ����� ������� Unscaled Time, Update Mode � ���������, ��� �� �� ���� �� ����������� ��������� ������� !!!
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;                // � ����� ��� ���

    [SerializeField] private GameObject pauseMenuUI;        // ������ �� ���� �����
    [SerializeField] private GameObject deathMenuUI;        // ������ �� ���� ������

    public static PauseMenu instance;                       // ��������

    private void Awake()
    {
        // ���� �������� � ���� �������� ������ ������, ����������
        if (instance)
            GameObject.Destroy(gameObject);
        else
            instance = this;
    }

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
        SceneTransition.SwitchToScene("StartMenu");
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

    public void Die()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0.5f;
    }
}

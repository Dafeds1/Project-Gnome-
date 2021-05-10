using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ������� ���� �� ��������� �����
public class StartMenu : MonoBehaviour
{
    // ������ ������� ������
    public void NewGame()
    {
        Saver.instance.ResetProgress();
        SceneTransition.SwitchToScene("Level1");
    }

    // ���������� � ����������
    public void ContinueGame()
    {
        SceneTransition.SwitchToScene(Saver.instance.currentLavel);
    }

    // ����� �� ����
    public void QuitGame()
    {
        Application.Quit();
    }
}

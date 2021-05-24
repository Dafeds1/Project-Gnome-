using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �������� �� ������� ����� �������� � ��������� ���������� ������
public class SceneTransition : MonoBehaviour
{
    public static AsyncOperation loadingSceneOperation; //  ��������� ������ �� �������� ��������, ���������� ��� ���������� ������������

    private static SceneTransition instance;            //  ��������, ��� ���������� ������������ ������ ����� �����
    private static bool shuldPlayBleckout = false;      //  ��������� �� �������� ���������� ������, ��� �� �� ���������� �� ��������� �����

    private Animator bleckoutAnimator;                  // ������ �� �������� � ����������� ������

    // ����������� �� ����� �� ��������
    public static void SwitchToScene(string sceneName)
    {
        instance.bleckoutAnimator.SetTrigger(name: "BlackoutOn");

        loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingSceneOperation.allowSceneActivation = false;                 // �� ��������� ������� �� ������ �����, ���� �������� ���������� �� ����������
    }

    private void Start()
    {
        instance = this;
        bleckoutAnimator = GetComponent<Animator>();

        if (shuldPlayBleckout)
        {
            bleckoutAnimator.SetTrigger(name: "BlackoutOff");
        }
    }

    // ����������� �� ���������, � ����� �������� ����������, ��������� ������� �� ������������ ��� ��� ����������� ����� 
    public void OnAnimatoinOver()
    {
        shuldPlayBleckout = true;
        loadingSceneOperation.allowSceneActivation = true;
    }

    /*
    // ����� ������� ������� �������� ������������ ������, ������ �� ���� ������ �� ������������ ���, ������ ��� � ����� ����� ��������
    public void OffAnimatoinOver() 
    {
        bleckoutAnimator.ResetTrigger(name: "BlackoutOff");
    }
    */
}

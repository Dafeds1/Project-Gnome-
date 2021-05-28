using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ����� ������������� ����������� ��������� ��������, �.�. ��� �������� � Update, ������� � ������������ � ������ ��������.
public class LoaderProgressBar : MonoBehaviour
{
    public Text procent;        // ������ �� ����� � ���������� ��������
    public Image progressBar;   // ������ �� ����������� ��������

    void Update()
    {
        // �������� ������ loadingSceneOperation � ����������� �������� � ����� ������������ ������, ������ ����� �� ������ SceneTransition
        if (SceneTransition.loadingSceneOperation != null)
        {
            procent.text = Mathf.RoundToInt(SceneTransition.loadingSceneOperation.progress * 100) + "%";
            progressBar.fillAmount = SceneTransition.loadingSceneOperation.progress;
        }
    }
}

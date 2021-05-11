using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// ������� ���� ���������� � Json ��������.
public class Saver : MonoBehaviour
{
    // ����������� ����������
    public int heroHealth;
    public int score;
    public string currentLavel;

    public static Saver instance;    // ����������� ������ �� ���� �� �����. ������� ���������

    private string savePath = "Assets/Scripts/Saver/save.txt";
    void Start()
    {
        // �� ���� ����������� ��������� ������ ��������� ����� ������ �� �����.
        if (instance)
            GameObject.Destroy(this.gameObject);
        else
            instance = this;

        // ���� ��� ����� ����������, ������� ��� � ������ ���������� ���������
        if (!File.Exists(savePath))
        {
            File.Create(savePath).Close();
            ResetProgress();
        }

        Load();
    }

    // ��� ������� ������� ��� ������� ��������� ��� ����� ����, �������� ������ �� ������� ��������������� ����� StartSave *** ����� ������ ���������� ��  ***
    public void ResetProgress()
    {
        string startSave = "Assets/Scripts/Saver/StartSave.txt";
        JsonUtility.FromJsonOverwrite(File.ReadAllText(startSave), instance);
        Save();
    }

    // ��������� � ����
    public void Save()
    {
        File.WriteAllText(savePath,JsonUtility.ToJson(instance));
    }

    // ��������� �� �����
    public void Load()
    {
        JsonUtility.FromJsonOverwrite(File.ReadAllText(savePath), instance);
    }
}

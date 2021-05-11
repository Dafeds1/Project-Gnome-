using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Создает файл сохарнения с Json строками.
public class Saver : MonoBehaviour
{
    // сохроняемые переменные
    public int heroHealth;
    public int score;
    public string currentLavel;

    public static Saver instance;    // статическая ссылка на этот же класс. вариант синглтона

    private string savePath = "Assets/Scripts/Saver/save.txt";
    void Start()
    {
        // не дает возможность создавать второй экземпляр этого класса на сцене.
        if (instance)
            GameObject.Destroy(this.gameObject);
        else
            instance = this;

        // если нет файла сохранений, создаем его и задаем старторвые параметры
        if (!File.Exists(savePath))
        {
            File.Create(savePath).Close();
            ResetProgress();
        }

        Load();
    }

    // для первого запуска или сбросса прогресса для новой игры, сохранит данные из зарание подготовленного файла StartSave *** можно просто копировать Оо  ***
    public void ResetProgress()
    {
        string startSave = "Assets/Scripts/Saver/StartSave.txt";
        JsonUtility.FromJsonOverwrite(File.ReadAllText(startSave), instance);
        Save();
    }

    // Сохроняет в файл
    public void Save()
    {
        File.WriteAllText(savePath,JsonUtility.ToJson(instance));
    }

    // Загружает из файла
    public void Load()
    {
        JsonUtility.FromJsonOverwrite(File.ReadAllText(savePath), instance);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Отвечает за отоброжение количества жизней ГГ.
public class PlayerHealthBar : HealthBar
{
    [SerializeField] private List<Image> healths;   // Массив ссылак на картинки здоровья
    [SerializeField] private Sprite healthOn;       // Картинка очка здоровья
    [SerializeField] private Sprite healthOff;      // Картинка отсутствующего здоровья

    public static PlayerHealthBar instance;         // Синглтон

    private void Awake()
    {
        // если объектов с этим скриптом больее одного, уничтожаем
        if (instance)
            GameObject.Destroy(gameObject);
        else
            instance = this;
    }

    public override void Initialize(int maxHealth)
    {
        // Создаем картинки для отображения хп(количество зависит от макс хп)и получаем на них ссылки в массив.
        healths = new List<Image>();
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject go = new GameObject();
            go.transform.SetParent(transform);
            healths.Add(go.AddComponent<Image>());
        }

        base.Initialize(maxHealth);
    }

    // Меняет отображаемое количество здоровья
    public override void ChangeHealth(int healthCount)
    {
        for (int i = 0; i < healths.Count; i++)
        {
            if (i < healthCount)
                healths[i].sprite = healthOn;
            else
                healths[i].sprite = healthOff;
        }
    }
}

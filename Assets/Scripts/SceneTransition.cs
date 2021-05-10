using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Отвечает за переход между уровнями с анимацией затемнения экрана
public class SceneTransition : MonoBehaviour
{
    public static AsyncOperation loadingSceneOperation; //  публичная ссылка на прогресс загрузки, восновдном для отдельного прогрессбара

    private static SceneTransition instance;            //  Синглтон, для публичного статического метода смены сцены
    private static bool shuldPlayBleckout = false;      //  Запускать ли анимацию расцеватия экрана, что бы не запускался на стартовой сцене

    private Animator bleckoutAnimator;                  // Ссылка на аниматор с затемнением экрана

    // Переключает на сцену по названию
    public static void SwitchToScene(string sceneName)
    {
        instance.bleckoutAnimator.SetTrigger(name: "BleckoutOn");

        loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingSceneOperation.allowSceneActivation = false;                 // Не разрешаем перейти на другую сцену, пока анимация затемнения не закончится
    }

    private void Start()
    {
        instance = this;
        bleckoutAnimator = GetComponent<Animator>();

        if (shuldPlayBleckout)
            bleckoutAnimator.SetTrigger(name: "BleckoutOff");
    }

    // Запускается из аниматора, в конце анимации затемнения, разрешает перейти на подгрузаемую или уже подруженную сцену 
    public void OnAnimatoinOver()
    {
        shuldPlayBleckout = true;
        loadingSceneOperation.allowSceneActivation = true;
    }
}

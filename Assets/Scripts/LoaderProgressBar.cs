using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Класс отслеживающий отоброжения прогресса загрузки, т.к. это делается в Update, вынесен и активируется в момент загрузки.
public class LoaderProgressBar : MonoBehaviour
{
    public Text procent;        // ссылка на текст с процентами загрузки
    public Image progressBar;   // ссылка на заполняемую картинку

    void Update()
    {
        if (SceneTransition.loadingSceneOperation != null)
        {
            procent.text = Mathf.RoundToInt(SceneTransition.loadingSceneOperation.progress * 100) + "%";
            progressBar.fillAmount = SceneTransition.loadingSceneOperation.progress;
        }
    }
}

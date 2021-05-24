using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  ласс отслеживающий отоброжени€ прогресса загрузки, т.к. это делаетс€ в Update, вынесен и активируетс€ в момент загрузки.
public class LoaderProgressBar : MonoBehaviour
{
    public Text procent;        // —сылка на текст с процентами загрузки
    public Image progressBar;   // —сылка на заполн€емую картинку

    void Update()
    {
        // ѕередаем данные loadingSceneOperation в взаполнение картинки и цифры загрузочного текста, данные перет из класса SceneTransition
        if (SceneTransition.loadingSceneOperation != null)
        {
            procent.text = Mathf.RoundToInt(SceneTransition.loadingSceneOperation.progress * 100) + "%";
            progressBar.fillAmount = SceneTransition.loadingSceneOperation.progress;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Text procent;
    public Image progressBar;

    private static SceneTransition instance;
    private static bool shuldPlayBleckout = false;

    private Animator bleckoutAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        instance.bleckoutAnimator.SetTrigger(name: "BleckoutOn");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        instance.loadingSceneOperation.allowSceneActivation = false;
    }

    private void Start()
    {
        instance = this;
        bleckoutAnimator = GetComponent<Animator>();

        if (shuldPlayBleckout)
            bleckoutAnimator.SetTrigger(name: "BleckoutOff");
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            procent.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
            progressBar.fillAmount = loadingSceneOperation.progress;
        }
    }

    public void OnAnimatoinOver()
    {
        shuldPlayBleckout = true;
        instance.loadingSceneOperation.allowSceneActivation = true;
    }
}

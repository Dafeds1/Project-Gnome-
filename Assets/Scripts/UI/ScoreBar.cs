using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Отображение количества заработанных очков играком
public class ScoreBar : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;

    void Start()
    {
        scoreText.text = ": "+score;
    }

    public void SetScore(int score, bool plas)
    {
        if (plas)
            this.score += score;
        else
            this.score = score;

        scoreText.text = ":" + score;
    }
}

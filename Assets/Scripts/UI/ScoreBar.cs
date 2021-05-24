using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ќтображение количества заработанных очков играком.
//  *** в данный момент не используетс€ ***
public class ScoreBar : MonoBehaviour
{
    [SerializeField] private int score;         // “екущие количество очков игрока.
    [SerializeField] private Text scoreText;    // —сылка на текст, количества очков.

    void Start()
    {
        scoreText.text = ": "+score;    // ќтображаем очки при старте сцены.
    }

    // ћетод задает текущие количество очков или добавл€ет к тому что есть.
    public void SetScore(int score, bool plas)
    {
        if (plas)
            this.score += score;
        else
            this.score = score;

        scoreText.text = ":" + score;
    }
}

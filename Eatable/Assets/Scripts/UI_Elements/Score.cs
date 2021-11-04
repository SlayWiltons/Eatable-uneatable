using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score = 0;

    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI gameOverScore;
    [SerializeField] Game_Config gameConfig;

    private void Start()
    {
        UpdateScore();
    }

    //Добавляем очки при правильном ответе
    public void AddScore()
    {
        score += gameConfig.starsReward;
        UpdateScore();
    }

    //Перезапуск
    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }

    //Вывод счёта в меню при окончании игры
    public void ShowGameOverScore()
    {
        gameOverScore.text = "Cчёт: " + score.ToString();
    }

    //Обновление счёта с отображением в UI
    public void UpdateScore()
    {
        scoreUI.text = score.ToString();
    }
}

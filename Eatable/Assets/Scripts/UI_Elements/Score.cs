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

    //��������� ���� ��� ���������� ������
    public void AddScore()
    {
        score += gameConfig.starsReward;
        UpdateScore();
    }

    //����������
    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }

    //����� ����� � ���� ��� ��������� ����
    public void ShowGameOverScore()
    {
        gameOverScore.text = "C���: " + score.ToString();
    }

    //���������� ����� � ������������ � UI
    public void UpdateScore()
    {
        scoreUI.text = score.ToString();
    }
}

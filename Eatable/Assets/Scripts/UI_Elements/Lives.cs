using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    private int lives = 0;

    [SerializeField] Game_Config game_Config;
    [SerializeField] GameEvent gameOver;
    [SerializeField] TextMeshProUGUI livesCount;

    private void Start()
    {
        lives = game_Config.lives;
        UpdateLives();
    }

    public void LivesReset()
    {
        lives = game_Config.lives;
        UpdateLives();
    }

    public void DecreaseLives()
    {
        lives--;
        if (lives >= 0) //����������� ���������� ������ ��������������� ���������� ������
        {
            UpdateLives();
        }
        if (lives == 0)
        {
            //�������� ������� ��� ���� ������
            gameOver.Raise();
        }
    }

    //���������� ����� �� UI
    public void UpdateLives()
    {        
        livesCount.text = lives.ToString();
    }
}

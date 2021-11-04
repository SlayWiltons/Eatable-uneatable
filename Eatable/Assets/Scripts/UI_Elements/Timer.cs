using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] Game_Config game_config;
    [SerializeField] GameEvent timeOver;
    [SerializeField] Animator animator;
    [SerializeField] GameObject timerUI;

    private void Start()
    {
        //Установка скорости работы UI таймера и его запуск
        animator.speed = 1 / game_config.time;
        StartCoroutine(CardTime());
    }

    //Перезапуск таймера
    public void StartTimer()
    {
        StopAllCoroutines();
        StartCoroutine(CardTime());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
        timerUI.SetActive(false);
    }

    private IEnumerator CardTime()
    {
        //Перезапуск UI
        animator.Play("Timer Bar", -1, 0.0f);
        yield return new WaitForSeconds(game_config.time);
        timeOver.Raise();
    }

    //Включение UI при перезапуске игры
    public void ActivateUI()
    {
        timerUI.SetActive(true);
    }
}

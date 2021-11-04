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
        //��������� �������� ������ UI ������� � ��� ������
        animator.speed = 1 / game_config.time;
        StartCoroutine(CardTime());
    }

    //���������� �������
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
        //���������� UI
        animator.Play("Timer Bar", -1, 0.0f);
        yield return new WaitForSeconds(game_config.time);
        timeOver.Raise();
    }

    //��������� UI ��� ����������� ����
    public void ActivateUI()
    {
        timerUI.SetActive(true);
    }
}

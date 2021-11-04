using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Game_Config", menuName ="Game_Config")]

public class Game_Config : ScriptableObject
{
    //������-������� �� �����
    public int starsReward;

    //���-�� ������
    public int lives;

    //����� �� �����
    public float time;

    //����������� ���������� ����� - �� ����� ��� � ��� ���� ������������
    public int maxCombo;

    //�������� ��������� ���������� ��� ���������� ����
    public Prototype[] prototypes;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Game_Config game_Config;

    bool active = true;

    private void Start()
    {
        GenerateCard();
    }

    //���������� ��������
    public void GenerateCard()
    {
        if (active)
        {
            Card newCard = Instantiate(cardPrefab, transform);
            newCard.SetData(randomPrototype());
        }
    }

    //�������� ��������� ������ ��� ��������� ��������
    private Prototype randomPrototype()
    {
        int randomId = Random.Range(0, game_Config.prototypes.Length);
        return game_Config.prototypes[randomId];
    }

    //��������� ������� ��� ����������� ����
    public void Activate()
    {
        active = true;
    }

    //���������� ������� ��� ��������� ���� (����� �� ����������� ����� ��������)
    public void Deactivate()
    {
        active = false;
    }
}

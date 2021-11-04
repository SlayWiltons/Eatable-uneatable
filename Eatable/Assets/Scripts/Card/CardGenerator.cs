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

    //Генерируем карточку
    public void GenerateCard()
    {
        if (active)
        {
            Card newCard = Instantiate(cardPrefab, transform);
            newCard.SetData(randomPrototype());
        }
    }

    //Отбираем случайные данные для генерации карточки
    private Prototype randomPrototype()
    {
        int randomId = Random.Range(0, game_Config.prototypes.Length);
        return game_Config.prototypes[randomId];
    }

    //Активация фабрики при перезапуске игры
    public void Activate()
    {
        active = true;
    }

    //Отключение фабрики при окончании игры (чтобы не создавались новые карточки)
    public void Deactivate()
    {
        active = false;
    }
}

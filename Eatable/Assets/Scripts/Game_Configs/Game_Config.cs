using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Game_Config", menuName ="Game_Config")]

public class Game_Config : ScriptableObject
{
    //Звезды-награды за ответ
    public int starsReward;

    //Кол-во жизней
    public int lives;

    //Время на ответ
    public float time;

    //Максимально допустимое комбо - не понял как и для чего использовать
    public int maxCombo;

    //Перечень имеющихся прототипов для конкретной игры
    public Prototype[] prototypes;
}

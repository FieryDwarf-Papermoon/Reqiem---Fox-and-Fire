using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeControlCreature // Команды
{
    Player,
    Computer,
}
public class BattleUI : MonoBehaviour
{

    public Image[] icons = new Image[4];
    public Text[] texts = new Text[4];

    [SerializeField] GameBattle gameBattle;

    [SerializeField] List<Creature> creatures;

    [SerializeField] TypeControlCreature typeControlCreature;

    void Start()
    {
        switch (typeControlCreature)
        {
            case TypeControlCreature.Player: creatures = gameBattle.SetPlayerCreature();
                break;
            case TypeControlCreature.Computer: creatures = gameBattle.SetComputerCreature();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (creatures[i] != null)
            {
                icons[i].sprite = creatures[i].Icon;
                texts[i].text = creatures[i].Count.ToString();
            }else
            {
                icons[i].sprite = null;
                texts[i].text = null;
            }
        }
    }
}

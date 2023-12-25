using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHeries : MonoBehaviour
{


    public TypeDirectorHeroes DirectorHeroes;
    public Text textATK;
    public Text textDEF;
    public Text textMP;
    public Text textSPEEL;
    public Text textMOVE;
    public Text textLEVEL;
    public Text textClass;

    public UICreature[] iCreatures = new UICreature[4];

    public void StatsUpdata()
    {
        textATK.text = "ATK: " + DirectorHeroes.Selects.SporeAttack;
        textDEF.text = "DEF: " + DirectorHeroes.Selects.SporeDef;
        textMP.text = "MP: " + DirectorHeroes.Selects.SporeMagiaPower;
        textSPEEL.text = "SPEEL: " + DirectorHeroes.Selects.SporeSpeel;
        textMOVE.text = "Move: " + DirectorHeroes.Selects.SporeMove + "/" + DirectorHeroes.Selects.MaxSporeMove;
        textLEVEL.text = "LEVEL: " + DirectorHeroes.Selects.Level;
        textClass.text = DirectorHeroes.Selects.NameType;

        for (int i = 0; i < 4; i++)
        {
            if (DirectorHeroes.Selects.creatures[i] != null)
            {
                iCreatures[i].text.text = "" + DirectorHeroes.Selects.creatures[i].Count;
                iCreatures[i].image.sprite = DirectorHeroes.Selects.creatures[i].Icon;
            }    
        }
    }
    void Start()
    {
        StatsUpdata();
    }

    // Update is called once per frame
    void Update()
    {
        StatsUpdata();
    }
}

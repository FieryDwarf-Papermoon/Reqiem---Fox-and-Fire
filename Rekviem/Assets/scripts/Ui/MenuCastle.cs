using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCastle : MonoBehaviour
{
    [SerializeField] private GameObject MapDirector;

    [SerializeField] private GameObject MassHeroes;

    [SerializeField] private MusicMasanger musicMasanger;

    [SerializeField] Castle castle;

    FactoryHeroes factory = new FactoryHeroes();

    [SerializeField] FactoryCreature factoryCreature;

    [SerializeField] UICreature[] _gorizonts = new UICreature[5];

    [SerializeField] Text textMoneyPlayer;

    [SerializeField] Players players;

    [SerializeField] UIGold uIGold;

    public void Actives(bool active, Castle _castle)
    {
        if (active)
        {       
            castle = _castle;
        }
        else
        {
            castle = null;
        }

        if (active)
        {
            musicMasanger.MusicCastle();
        }
        else
        {
            musicMasanger.MusicGlass();
        }

        gameObject.SetActive(active);
        MapDirector.SetActive(!active);

        UpdataMoneyPlayer();
        PrintGorisont();
    }

    public void PrintGorisont()
    {
        if (castle != null)
        {
            _gorizonts[0].image.sprite = castle.gorizont.Icon;

            for (int i = 0; i < 4; i++)
            {
                _gorizonts[i + 1].image.sprite = castle.gorizont.creatures[i].Icon;
                _gorizonts[i + 1].text.text = castle.gorizont.creatures[i].Count.ToString();
            }
        }
        else
        {
            _gorizonts[0].image.sprite = null;

            for (int i = 0; i < 4; i++)
            {
                _gorizonts[i + 1].image.sprite = null;
                _gorizonts[i + 1].text.text = 0 + "";
            }
        }
    }

    public void UpdataMoneyPlayer()
    {
        textMoneyPlayer.text = "" + players.Gold;
    }

    public void CreateHeroes(ClassHeroes _prefab)
    {
        if (castle.gorizont == null && players.Gold >= 2500)
        {
            _prefab.teams = castle.teams;
            Vector3 vector3 = new Vector3(castle.transform.position.x, castle.transform.position.y + 0.5f, 0);
            ClassHeroes heroes = Instantiate(_prefab, vector3, Quaternion.identity);
            MapDirector.SetActive(true);
            heroes.transform.SetParent(MassHeroes.transform, true);
            castle.gorizont = heroes;
            players.Gold -= 2500;
            uIGold.UpdateGold();
            Actives(false, castle);
        }
    }

    public void PlusCreature(int number)
    {
        int gold = factoryCreature.creaturePrefab[number].Prise;

        if (players.Gold >= gold)
        {
            players.Gold -= gold;
            uIGold.UpdateGold();
            castle.gorizont.creatures[number].Count += 1;
            UpdataMoneyPlayer();
            PrintGorisont();  
        }
    }

    public void Exit()
    {
        Actives(false, null);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

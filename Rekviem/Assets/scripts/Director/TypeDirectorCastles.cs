using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TypeDirectorCastles : TypeDirector<Castle>
{

    public Tilemap FogOfWar;
    public Image image;

    
    [SerializeField] private MenuCastle menuCastle;
    [SerializeField] private TypeDirectorHeroes typeDirectorHeroes;

    private void Start()
    {
        UpdatePlayersHero();
    }

    private new void Awake()
    {
        T_List = new List<Castle>();
        UpdatePlayersHero();
    }

    public void ActiveMenu(bool active, Castle castle)
    {
        menuCastle.Actives(active, castle);
    }

    public bool SetActiveMenu()
    {
        return menuCastle.gameObject.activeSelf;
    }

    public new void MouseClickObgect(Castle T_OBG) // Клики мышки
    {
        float TimeSince_LastClick = Time.time - last_CLICK_Time;

        if (TimeSince_LastClick <= DOUBLE_CLICK_Time && players.teams == T_OBG.teams)
        {// Double Click
            ActiveMenu(true, Selects);
        }
        else
        {// Normal Click
            if (players.ChoiceObject(T_OBG.castle, T_OBG.teams))
            {
                SetObject(T_OBG);
            }
        }

        last_CLICK_Time = Time.time;
    }

    public void SetObject(Castle T_OBG) //Выбор объекта
    {
        if (!typeDirectorHeroes.SetHasMode())
        {
            players.PlusObject(T_OBG.castle);
            Vector3 vector3 = new Vector3(T_OBG.castle.transform.position.x, T_OBG.castle.transform.position.y, -10f);
            _camera.position = vector3;
            Debug.Log(T_OBG.NameType);
            Selects = T_OBG;
            image.sprite = T_OBG.Icon;
        } 
    }

    public void VozvratkSelects() //UI
    {
        SetObject(Selects);
    }

    public void SelectObgect(Castle T_OBG) // Выбор первого объекта
    {

        if (players.ChoiceObject(T_OBG.castle, T_OBG.teams))
        {
            SetObject(T_OBG);
        }
    }

    public void UpdatePlayersHero()
    {
        T_List_Players.Clear();
        foreach (Castle item in T_List)
        {
            if (players.teams == item.teams)
            {
                T_List_Players.Add(item);
            }
        }

    }

    public void PerehodT_List()
    {
        int Number = T_List_Players.IndexOf(Selects);
        Debug.Log(Number);

        if (T_List_Players.Count > Number + 1)
        {
            SetObject(T_List_Players[Number + 1]);
        }
        else
        {
            SetObject(T_List_Players[0]);
        }
    }



    public void UpdateFogOfWar(Castle castle)
    {
        if (players.teams == castle.teams)
        {
            Vector3Int vector3Int = FogOfWar.WorldToCell(castle.transform.position);

            for (int x = -castle.visible; x <= castle.visible; x++)
            {
                for (int y = -castle.visible; y <= castle.visible; y++)
                {
                    FogOfWar.SetTile(vector3Int + new Vector3Int(x, y, 0), null);
                }
            }
        }  
    }

    public bool PlayerWinCastle()
    {
        foreach (Castle item in T_List)
        {
            if (item.teams != players.teams)
            {
                return false;
            }
        }
        return true;
    }

    public void UpdateMove()
    {
        foreach (Castle item in T_List_Players)
        {
            players.Gold += 1000;
        }
    }

}

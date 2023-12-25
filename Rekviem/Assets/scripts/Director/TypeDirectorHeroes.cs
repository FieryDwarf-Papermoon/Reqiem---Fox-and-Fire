using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TypeDirectorHeroes : TypeDirector<ClassHeroes>
{
    protected float speed = 0.05f;

    private Vector2 movementInpat;

    private Vector3 direction;

    private Vector3 startPosition;

    private Vector3 endPosition;

    public Tilemap FogOfWar;
    public Tilemap Territory;
    public Image image;
    

    [SerializeField] private bool hasMoved;
    [SerializeField] private GameMasanger gameMasanger;
    public new void MouseClickObgect(ClassHeroes T_OBG) // Клики мышки
    {
        float TimeSince_LastClick = Time.time - last_CLICK_Time;

        if (TimeSince_LastClick <= DOUBLE_CLICK_Time) 
        {// Double Click

        }
        else
        {// Normal Click
            if (players.ChoiceObject(T_OBG.hero, T_OBG.teams))
            {
                SetObject(T_OBG);
            }
        }

        last_CLICK_Time = Time.time;
    }

    public bool SetHasMode()
    {
        return hasMoved;
    }

    public void SelectObgect(ClassHeroes T_OBG) // Выбор первого объекта
    {
       
            if (players.ChoiceObject(T_OBG.hero, T_OBG.teams))
            {
                SetObject(T_OBG);
            }
    }

    public void SetObject(ClassHeroes T_OBG) //Выбор объекта
    {
        if (!hasMoved)
        {
            players.PlusObject(T_OBG.hero);
            Vector3 vector3 = new Vector3(T_OBG.hero.transform.position.x, T_OBG.hero.transform.position.y, -10f);
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

    public void StopWalk(ClassHeroes heroes)
    {
        if (heroes.hero == Selects.hero)
        {
            hasMoved = false;
            Selects.hero.transform.position = startPosition;
            movementInpat = new Vector2(0, 0);
            _camera.position = new Vector3(Selects.transform.position.x, Selects.transform.position.y, _camera.position.z);
            //Selects.SporeMove++;
        }
    }

    protected void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        if (players.ControlObject(Selects.hero)) //передвижение
        {

            if (Selects.SporeMove != 0)
            {
                if (!hasMoved)
                {
                    
                    if ((movementInpat.x != 0 || movementInpat.y != 0))
                    {
                        GetDirectionMove();
                        Vector3Int vector3Int = Territory.WorldToCell(Selects.hero.transform.position + direction);

                        if (Territory.GetTile(vector3Int))
                        {
                            startPosition = Selects.transform.position;
                            endPosition = Selects.hero.transform.position + direction;
                            hasMoved = true;
                        }
                    }
                    else
                    {
                        movementInpat = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    }
                }
                else
                {
                    GetMovementDirection();
                }
                
                
            }
        }
    }

    private void GetDirectionMove()
    {
        if (movementInpat.x > 0)
        {
            direction = new Vector3(1, 0);

        }
        else if (movementInpat.x < 0)
        {
            direction = new Vector3(-1, 0);
        }
        else if (movementInpat.y > 0)
        {
            direction = new Vector3(0, 1);
        }
        else
        {
            direction = new Vector3(0, -1);
        }
    }

    private bool ContrastFloat(float A, float B, int Stepeny)
    {
        switch (Stepeny)
        {
            case 0:
                {
                    if (A >= B)
                    {
                        return true;
                    }
                }; break;
            case 1:
                {
                    if (A <= B)
                    {
                        return true;
                    }
                }; break;
            default:
                break;
        }
        return false;
    }
    private bool MoveendPosition()
    {
        if (direction.x > 0)
        {

            return ContrastFloat(Selects.transform.position.x, endPosition.x, 0);

        }
        else if (direction.x < 0)
        {
            return ContrastFloat(Selects.transform.position.x, endPosition.x, 1);
        }
        else if (direction.y > 0)
        {
            return ContrastFloat(Selects.transform.position.y, endPosition.y, 0);
        }
        else
        {
            return ContrastFloat(Selects.transform.position.y, endPosition.y, 1);
        }
    }

    private void GetMovementDirection() // движение точку
    {
       
        if (!MoveendPosition())
        {
            Selects.transform.position += new Vector3(direction.x * speed, direction.y * speed);
            //Debug.Log(endPosition.x + " " + endPosition.y);
            //Debug.Log(direction.x * speed + " " + direction.y * speed);

            _camera.position = new Vector3(Selects.transform.position.x, Selects.transform.position.y, _camera.position.z); //перемещение камеры
        }
        else
        {
            hasMoved = false;
            Selects.SporeMove--;
            movementInpat = new Vector2(0, 0);
            Selects.transform.position = endPosition;
        }

    }

    private new void Awake()
    {
        T_List = new List<ClassHeroes>();
        UpdatePlayersHero();
    }

    private void Start()
    {
        UpdatePlayersHero();
        hasMoved = false;
    }

    public void UpdateFogOfWar(ClassHeroes heroes)
    {
        if (players.teams == heroes.teams)
        {
            Vector3Int vector3Int = FogOfWar.WorldToCell(heroes.transform.position);

            for (int x = -heroes.Visible; x <= heroes.Visible; x++)
            {
                for (int y = -heroes.Visible; y <= heroes.Visible; y++)
                {
                    FogOfWar.SetTile(vector3Int + new Vector3Int(x, y, 0), null);
                }
            }
        }
    }

    public void UpdatePlayersHero()
    {
        T_List_Players.Clear();
        foreach (ClassHeroes item in T_List)
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

    public bool PlayerWinHero()
    {
        foreach (ClassHeroes item in T_List)
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
        foreach (ClassHeroes item in T_List)
        {
            item.SporeMove = item.MaxSporeMove;  
        }
        gameMasanger.OverGame();
    }
}

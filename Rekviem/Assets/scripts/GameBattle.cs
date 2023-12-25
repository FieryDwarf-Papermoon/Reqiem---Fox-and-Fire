using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameBattle : MonoBehaviour
{
    public const int SizeLine = 7;
    
    [SerializeField] public CellGrid[,] grids = new CellGrid[SizeLine, SizeLine];

    [SerializeField] private ClassHeroes PlayerHero;
    [SerializeField] private ClassHeroes ComputerHero;
    [SerializeField] private Transform cinematik;
    [SerializeField] private Transform creatures;
    [SerializeField] private GameMasanger gameMasanger;

    public List<Creature> PlayerCreatures = new List<Creature>();

    public List<Creature> ComputerCreatures = new List<Creature>();

    public List<Creature> FullCreatures = new List<Creature>();

    public Creature CurrentCreature;

    public void StartBattleHero(ClassHeroes _player, ClassHeroes _computer)
    {
        PlayerCreatures.Clear();
        ComputerCreatures.Clear();
        FullCreatures.Clear();

        cinematik.position = new Vector3(0, 0, cinematik.transform.position.z); ;

        PlayerHero = _player;
        ComputerHero = _computer;

        for (int i = 0; i < 4; i++)
        {
            PlayerCreatures.Add(PlayerHero.creatures[i]);
            ComputerCreatures.Add(ComputerHero.creatures[i]);

            if (PlayerCreatures[i] != null)
            {
               
                grids[i * 2, 0].creature = Instantiate(PlayerCreatures[i], grids[i * 2, 0].transform.position, Quaternion.identity);
                PlayerCreatures[i] = grids[i * 2, 0].creature;
                PlayerCreatures[i].gameObject.SetActive(true);
                SetStatHero(PlayerHero, PlayerCreatures[i]);

                PlayerCreatures[i].transform.SetParent(creatures);
            }
               

            if (ComputerCreatures[i] != null)
            {
                
                grids[i * 2, SizeLine - 1].creature = Instantiate(ComputerCreatures[i], grids[i * 2, SizeLine - 1].transform.position, Quaternion.identity);
                ComputerCreatures[i] = grids[i * 2, SizeLine - 1].creature;
                ComputerCreatures[i].gameObject.SetActive(true);
                SetStatHero(ComputerHero, ComputerCreatures[i]);

                ComputerCreatures[i].transform.SetParent(creatures);
            }

            FullCreatures.Add(PlayerCreatures[i]);
            FullCreatures.Add(ComputerCreatures[i]);
        }
        if (FullCreatures.Count > 0)
        {
            foreach (var item in FullCreatures)
            {
                if (item != null)
                {
                    SetControlCurrent(item);
                    break;
                }
            }
        }
    }

    private void SetStatHero(ClassHeroes heroes, Creature creature)
    {
        creature.ATK += heroes.SporeAttack;
        creature.DEF += heroes.SporeDef;
        creature.SPR += heroes.SporeSpeel;
        creature.MP += heroes.SporeMagiaPower;
    }
    public void UpdatePrintCell()
    {
        for (int i = 0; i < SizeLine; i++)
        {
            for (int j = 0; j < SizeLine; j++)
            {
                grids[i,j].transform.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    private int XCell(CellGrid cell)
    {
        int X = Convert.ToInt16(cell.transform.position.x);

        return X + SizeLine / 2; ;
    }

    private int YCell(CellGrid cell)
    {
        int Y = Convert.ToInt16(cell.transform.position.y);

        return Y + SizeLine / 2; ;
    }

    private void PlayerControl()
    {

    }

    private void ComputerControl()
    {
        NextCreature();
    }

    private void SetControlCurrent(Creature creature)
    {
        CurrentCreature = creature;
        if (ItPlayerCreature(CurrentCreature))
        {
            PlayerControl();
        }
        else
        {
            ComputerControl();
        }
    }

    public void NextCreature()
    {
        int number = FullCreatures.IndexOf(CurrentCreature) + 1;

        for (; number < FullCreatures.Count; number++)
        {
            if (FullCreatures[number] != null)
            {
                SetControlCurrent(FullCreatures[number]);
                break;
            }
        }
        if (number >= FullCreatures.Count)
        {
            SetControlCurrent(FullCreatures[0]);
        }
    }

    public void SwapCurrentCreature(CellGrid cell)
    {
        int X = Convert.ToInt16(CurrentCreature.transform.position.x);
        int Y = Convert.ToInt16(CurrentCreature.transform.position.y);

        Creature crea = cell.creature;

        cell.creature = CurrentCreature;
        if (CurrentCreature != null) CurrentCreature.transform.position = cell.transform.position;

        grids[Y + SizeLine / 2, X + SizeLine / 2].creature = crea;
        if (crea != null) crea.transform.position = grids[Y + SizeLine / 2, X + SizeLine / 2].transform.position;
    }

    public int Register(CellGrid cell)
    {

        grids[YCell(cell), XCell(cell)] = cell;
        return (YCell(cell)) * SizeLine + XCell(cell);
    }

    public bool ItPlayerCreature(Creature creature)
    {
        for (int i = 0; i < 4; i++)
        {
            if (PlayerCreatures[i] == creature)
            {
                return true;
            }
        }
        return false;
    }

    public List<Creature> SetPlayerCreature()
    {
        return PlayerCreatures;
    }

    public List<Creature> SetComputerCreature()
    {
        return ComputerCreatures;
    }

    public void Attact(CellGrid cellGrid)
    {
        switch (CurrentCreature.SetAttack())
        {
            case TypeAttack.Melle: MelleAttack(cellGrid);
                break;
            case TypeAttack.Ranger: RangerAttack(cellGrid);
                break;
            default:
                break;
        }
        AnalitikWin();
    }

    private void MelleAttack(CellGrid cellGrid)
    {
        int Y= YCell(cellGrid);
        int X= XCell(cellGrid);

        if (Access(X + 1, Y))
        {
            SwapCurrentCreature(grids[Y, X + 1]);
            
        }
        else if (Access(X - 1, Y))
        {
            SwapCurrentCreature(grids[Y, X - 1]);
            
        }
        else if (Access(X, Y - 1))
        {
            SwapCurrentCreature(grids[Y - 1, X]);
            
        }
        else if (Access(X, Y + 1))
        {
            SwapCurrentCreature(grids[Y + 1, X]);
           
        }

        if (AccessDistantion(X, Y))
        {
            Debug.Log("Attack");
            int Damage = CurrentCreature.AccountDamagePSY(cellGrid.creature) * CurrentCreature.Count;
            cellGrid.creature.ThisAttack(Damage);

            CurrentCreature.attackEffect(cellGrid.creature.transform.position);
        }

    }

    private void RangerAttack(CellGrid cellGrid)
    {
        Debug.Log("Attack");
        int Damage = CurrentCreature.AccountDamageMagic(cellGrid.creature) * CurrentCreature.Count;
        cellGrid.creature.ThisAttack(Damage);

        CurrentCreature.attackEffect(cellGrid.creature.transform.position);
    }

    private bool AccessCell(int X, int Y)
    {
        if ((Y >= 0 && Y < SizeLine) && (X >= 0 && X < SizeLine))
        {
            return true;
        }
        else
        {
            return false;
        }

    } 

    private bool AccessDistantion(int X, int Y)
    {
        if (AccessCell(X, Y))
        {
            float distantion = Vector2.Distance(CurrentCreature.transform.position, grids[Y, X].transform.position);
            if (CurrentCreature.Speed >= distantion)
            {
                return true;
            }
        }
        return false ;
    }

    private bool Access(int X, int Y)
    {
        if (AccessCell(X, Y))
        {
            if (AccessDistantion(X, Y))
            {
                if (grids[Y, X].creature == null)
                {
                    return true;
                }
            }
            
        }
        return false;
    }

    private void ClearBattle()
    {
        foreach (var item in FullCreatures)
        {
            if (item != null)
            {
                Destroy(item.gameObject);
            }
        }
    }

    private bool ListNoNullCreatures(List <Creature> creatures)
    {
        for (int i = 0; i < creatures.Count; i++)
        {
            if (creatures[i] != null)
            {
                return true;
            }
        }
        return false;
    }

    public void AnalitikWin()
    {
        if (!ListNoNullCreatures(PlayerCreatures))
        {
            Destroy(PlayerHero.gameObject);
            ClearBattle();
            gameMasanger.OverBattle();
        }
        else if (!ListNoNullCreatures(ComputerCreatures))
        {
            Destroy(ComputerHero.gameObject);
            ClearBattle();
            gameMasanger.OverBattle();

        }
        else
        {

        }
    }

}

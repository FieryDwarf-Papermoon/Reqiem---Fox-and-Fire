using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CellGrid : MonoBehaviour
{
    [SerializeField] GameBattle gameBattle;

    [SerializeField] public int number;

    private SpriteRenderer spriteRenderer;

    public Creature creature;
    private void OnMouseEnter()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseExit()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDown()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.blue;

        float distantion = Vector2.Distance(gameBattle.CurrentCreature.transform.position, this.transform.position);

        if (creature == null)
        {
            if (gameBattle.CurrentCreature.Speed >= distantion)
            {
                gameBattle.UpdatePrintCell();
                gameBattle.SwapCurrentCreature(this);
                gameBattle.NextCreature();
            }
        }
        else
        {
            if (!gameBattle.ItPlayerCreature(creature))
            {
                gameBattle.Attact(this);
                gameBattle.NextCreature();
                gameBattle.UpdatePrintCell();
            }
        }

        gameBattle.AnalitikWin();
    }

    private void OnMouseUp()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Start()
    {
        number = gameBattle.Register(this);
    }

    private void PrintCellcyan()
    {
        if (gameBattle.CurrentCreature != null)
        {
            float distantion = 0;

            distantion = Vector2.Distance(gameBattle.CurrentCreature.transform.position, this.transform.position);

            if (gameBattle.CurrentCreature.Speed >= distantion)
            {
                if (creature == null)
                {
                    gameObject.transform.GetComponent<SpriteRenderer>().color = Color.cyan;
                }
                else
                {
                    gameObject.transform.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (gameObject.activeSelf == true)
        {
            if (creature != null)
            {
                if (creature == gameBattle.CurrentCreature)
                {
                    gameObject.transform.GetComponent<SpriteRenderer>().color = Color.magenta;
                }
            }
            else
            {
                PrintCellcyan();
            }
        } 
    }

}

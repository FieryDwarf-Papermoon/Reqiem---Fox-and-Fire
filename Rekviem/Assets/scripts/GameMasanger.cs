using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasanger : MonoBehaviour
{
    [SerializeField] TypeDirectorCastles directorCastles;
    [SerializeField] TypeDirectorHeroes directorHeroes;
    [SerializeField] MusicMasanger musicMasanger;
    [SerializeField] GameBattle gameBattle;
    [SerializeField] GameObject gameMap;
    [SerializeField] GameObject gameWin;
    [SerializeField] GameObject gameOver;

    int NumberMove = 0;

    int NotWinMoveCount = 30;
    public void StartGame(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameMap.SetActive(true);
    }

    public void StartBattle(ClassHeroes P, ClassHeroes C)
    {
        musicMasanger.MusicBattle();
        gameBattle.gameObject.SetActive(true);
        gameBattle.StartBattleHero(P, C);
        gameMap.SetActive(false);
    }

    public void OverBattle()
    {
        musicMasanger.MusicGlass();
        gameMap.SetActive(true);
        gameBattle.gameObject.SetActive(false);
        
    }

    public void OverGame()
    {
        NumberMove++;
        if (directorHeroes.PlayerWinHero() && directorCastles.PlayerWinCastle())
        {
            gameMap.SetActive(false);
            gameWin.SetActive(true);
        }
        else
        {
            if (NumberMove >= NotWinMoveCount)
            {
                musicMasanger.MusicCastle();
                gameMap.SetActive(false);
                gameOver.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    { 
        Application.Quit();
        Debug.Log("Exit");
    }

}

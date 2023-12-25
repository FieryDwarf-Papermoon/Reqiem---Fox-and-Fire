using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Fraction // Команды
{
    Null = 0,
    Ursus = 1

}

public enum HeroClass // Команды
{
    Null = 0,
    Witch = 1,
    Varmonger = 2

}

public class ClassHeroes : MonoBehaviour
{
    [SerializeField] protected TypeDirectorHeroes Director;
    [SerializeField] protected GameMasanger gameMasanger;
    [SerializeField] protected FactoryCreature factoryCreature;

    public GameObject hero;

    public Sprite Icon;

    //public Transform _camera;

    public Teams teams;

    [SerializeField] protected Fraction fraction;

    [SerializeField] protected HeroClass heroClass;

    //public Players players;

    public int MaxSporeMove;
    public int SporeMove;


    public int Visible;

    public string Name;

    public string NameType;

    public string Biografy;

    public int Level;

    public int SporeLevel;

    public int SporeDef;

    public int SporeAttack;

    public int SporeMagiaPower;

    public int SporeSpeel;

    public Creature[] creatures = new Creature[4];

    private void Start()
    {
        PlusFactory();
        Director = GameObject.FindGameObjectWithTag("DirectorHeroes").GetComponent<TypeDirectorHeroes>(); 
        gameMasanger = GameObject.FindGameObjectWithTag("GameMasanger").GetComponent<GameMasanger>();
        Director.Register(this);
        Director.SelectObgect(this);
        Director.UpdatePlayersHero();
        hero = gameObject;
        OnCreate();

    }

    private void OnDestroy()
    {
        Director.UnRegister(this);
    }

    protected void OnMouseDown()
    {

        Director.MouseClickObgect(this);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Director.StopWalk(this);
        if (collision != null && this == Director.Selects) if (collision.gameObject.GetComponent<ClassHeroes>() != null)
        {
                ClassHeroes heroes = collision.gameObject.GetComponent<ClassHeroes>();
                if (heroes.teams != this.teams)
                {
                    gameMasanger.StartBattle(this, heroes);
                }

        }
    }

    protected void PlusFactory()
    {
        factoryCreature = GameObject.FindGameObjectWithTag("FactoryCreature").GetComponent<FactoryCreature>();
    }

    protected void CreateCreatureinHero(int count, int number, int numberCreature)
    {
        creatures[number] = factoryCreature.CreateCreatures(numberCreature);
        creatures[number].CreateCreatures(count);
        creatures[number].gameObject.transform.SetParent(this.transform);
        creatures[number].gameObject.SetActive(false);
    }

    public string GetName()
    {
        return Name;
    }

    public string GetBiografy()
    {
        return Biografy;
    }

    public int GetLevel()
    {
        return Level;
    }

    protected void FixedUpdate()
    {
        Director.UpdateFogOfWar(this);
    }

    private void OnCreate()
    {

        SporeLevel = 0;
        Level = 1;

        switch (heroClass)
        {
            case HeroClass.Null:
                {
                    SporeDef = 0;
                    SporeAttack = 0;
                    SporeMagiaPower = 0;
                    SporeSpeel = 0;

                    MaxSporeMove = 1;
                    SporeMove = MaxSporeMove;
                    Visible = 1;
                    NameType = "Null";
                }
                break;
            case HeroClass.Witch:
                {
                    SporeDef = 0;
                    SporeAttack = 1;
                    SporeMagiaPower = 4;
                    SporeSpeel = 3;

                    MaxSporeMove = 6;
                    SporeMove = MaxSporeMove;
                    Visible = 4;
                    NameType = "Witch";
                    CreateCreatureinHero(30, 0, 0);
                    CreateCreatureinHero(5, 1, 1);
                    CreateCreatureinHero(3, 2, 2);
                    CreateCreatureinHero(7, 3, 3);
                }
                break;
            case HeroClass.Varmonger:
                {
                    SporeDef = 5;
                    SporeAttack = 2;
                    SporeMagiaPower = 0;
                    SporeSpeel = 1;

                    MaxSporeMove = 10;
                    SporeMove = MaxSporeMove;
                    Visible = 2;
                    NameType = "Varmonger";
                    CreateCreatureinHero(3, 0, 0);
                    CreateCreatureinHero(25, 1, 1);
                    CreateCreatureinHero(10, 2, 2);
                    CreateCreatureinHero(1, 3, 3);
                }
                break;
            default:
                break;
        }
    }

}

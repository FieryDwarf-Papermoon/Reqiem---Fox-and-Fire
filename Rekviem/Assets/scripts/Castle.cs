using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{

    public GameObject castle;

    public Sprite Icon;

    public Teams teams;

    public int visible;

    [SerializeField] protected Fraction fraction;

    [SerializeField] protected TypeDirectorCastles Director;

    public ClassHeroes gorizont;

    public string NameType;

    protected const float DOUBLE_CLICK_Time = 0.3f;

    protected float last_CLICK_Time;

    void Start()
    {
        Director = GameObject.FindGameObjectWithTag("DirectorCastle").GetComponent<TypeDirectorCastles>();
        Director.Register(this);
        Director.SelectObgect(this);
        castle = gameObject;
    }

    private void Awake()
    {
        Director = GameObject.FindGameObjectWithTag("DirectorCastle").GetComponent<TypeDirectorCastles>();
        Director.Register(this);

        switch (fraction)
        {
            case Fraction.Null:
                {
                    NameType = "Null";
                    visible = 2;
                }
                break;
            case Fraction.Ursus:
                {
                    NameType = "Fastness";
                    visible = 4;
                }
                break;
            default:
                break;
        }
    }

    protected  void OnMouseDown()
    {
        Director.MouseClickObgect(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Director.UpdateFogOfWar(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gorizont == null)
        {
            teams = collision.GetComponent<ClassHeroes>().teams;
            Director.UpdatePlayersHero();
            gorizont = collision.GetComponent<ClassHeroes>();
            Director.ActiveMenu(true, this);
        }
         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Director.SetActiveMenu())
        {
            gorizont = null;
            Director.ActiveMenu(false, this);
        }          
    }

}


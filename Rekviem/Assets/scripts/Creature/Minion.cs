using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Creature
{
    const string _attack = "attack";

    new void CreateState()
    {
        HP = 100;
        MaxHP = HP;
        Damage = 3;
        ATK = 0;
        DEF = 1;
        MP = 0;
        SPR = 30;
        Speed = 1;
        attack = TypeAttack.Melle;
        attackEffect = AttackEffection;

        Prise = 100;
        //Icon = factoryCreature.creaturePrefab[0].Icon;
    }
    // Start is called before the first frame update
    public new void CreateCreatures(int count)
    {
        CreateState();
        Count = count;
    }
    void Start()
    {
        PlusFactory();
    }

    private void Awake()
    {
        CreateState();
    }

    public void AttackEffection(Vector3 vector3)
    {
        audioSource.Play();
        animator.Play("Attack");
    }

    public void FixedUpdate()
    {

    }

    public void EndAttackEffect()
    {
        animator.Play("Stay");
    }

    public Minion(int count)
    {
        CreateCreatures(count);
    }

}

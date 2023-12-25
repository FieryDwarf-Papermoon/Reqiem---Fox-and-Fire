using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vityaz : Creature
{
    const string _attack = "attack";

    public new void CreateState()
    {
        HP = 60;
        MaxHP = HP;
        Damage = 10;
        ATK = 1;
        DEF = 10;
        MP = 0;
        SPR = 10;
        Speed = 3;
        attack = TypeAttack.Melle;
        attackEffect = AttackEffection;

        Prise = 250;
        //Icon = factoryCreature.creaturePrefab[1].Icon;
    }

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
        animator.Play("stay");
    }

    public Vityaz(int count)
    {
        CreateCreatures(count);
    }
}

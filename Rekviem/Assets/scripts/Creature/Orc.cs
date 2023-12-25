using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Creature
{
    // Start is called before the first frame update

    public new void CreateState()
    {
        HP = 70;
        MaxHP = HP;
        Damage = 30;
        ATK = 5;
        DEF = 25;
        MP = 0;
        SPR = 0;
        Speed = 2;
        attack = TypeAttack.Melle;
        attackEffect = AttackEffection;

        Prise = 450;
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

    public void EndAttackEffect()
    {
        animator.Play("Stay");
    }

    public Orc(int count)
    {
        CreateCreatures(count);
    }

}

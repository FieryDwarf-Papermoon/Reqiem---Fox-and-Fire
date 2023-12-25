using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhikada : Creature
{
    [SerializeField] GameObject Effect;
    public new void CreateState()
    {
        HP = 33;
        MaxHP = HP;
        Damage = 44;
        ATK = 0;
        DEF = 1;
        MP = 22;
        SPR = 1;
        Speed = 3;

        attack = TypeAttack.Ranger;
        attackEffect = AttackEffection;

        Prise = 600;
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
        GameObject effect = Instantiate(Effect, vector3, Quaternion.identity);
        Destroy(effect, 0.5f);
    }

    public void FixedUpdate()
    {

    }

    public void EndAttackEffect()
    {
        animator.Play("Stay");
    }

    public Zhikada(int count)
    {
        CreateCreatures(count);
    }

}

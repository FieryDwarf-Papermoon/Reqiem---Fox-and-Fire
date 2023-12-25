using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeAttack // Команды
{
    Melle,
    Ranger,
}
public class Creature : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected AudioSource audioSource;

    [SerializeField] public Sprite Icon;

    //[SerializeField] protected FactoryCreature factoryCreature;

    public int HP;

    public int MaxHP;

    public int Count;

    public int Damage;

    public int ATK;

    public int DEF;

    public int MP;

    public int SPR;

    public int Speed;

    public int Prise;

    protected TypeAttack attack;

    public delegate void AttackEffect(Vector3 vector3);

    public AttackEffect attackEffect;

    public int RealFullHP()
    {
        return MaxHP * (Count - 1) + HP;
    }

    public TypeAttack SetAttack()
    {
        return attack;
    }

    protected void PlusFactory()
    {
        //factoryCreature = GameObject.FindGameObjectWithTag("FactoryCreature").GetComponent<FactoryCreature>();
    }

    public int AccountDamagePSY(Creature creature)
    {
        return this.Damage + this.Damage * this.ATK / creature.DEF * 5/100;
    }

    public int AccountDamageMagic(Creature creature)
    {
        return this.Damage + this.Damage * this.MP / creature.SPR * 2 / 100;
    }

    public void ThisAttack(int EnemyDamage)
    {
        int CurrentFullHP = RealFullHP() - EnemyDamage;
        Debug.Log("Damage " + EnemyDamage);
        Debug.Log("Current Full HP " + CurrentFullHP);

        if (CurrentFullHP < 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Count = CurrentFullHP / MaxHP + 1;
            HP = CurrentFullHP % MaxHP;
        }

    }
    public void CreateState()
    {

    }

    public void CreateCreatures(int count)
    {
        Count = count;
    }

}

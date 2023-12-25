using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCreature : MonoBehaviour
{
    public Creature[] creaturePrefab = new Creature[4];

    public Creature CreateCreatures(int number)
    {
        return Instantiate(creaturePrefab[number]);
    }

}

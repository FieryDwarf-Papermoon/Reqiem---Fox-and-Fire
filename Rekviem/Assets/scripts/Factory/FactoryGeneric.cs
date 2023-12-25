using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryGeneric<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _pointtoSpawn;

    private int _index = 0;

    public T GetNewInstante()
    {

        Vector3 vector3 = _pointtoSpawn.position;

        return Instantiate(_prefab, vector3, Quaternion.identity);

    }
}

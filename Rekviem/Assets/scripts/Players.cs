using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Teams // �������
{
    Netrali = 0,
    Red = 1,
    Blue = 2
}

public class Players : MonoBehaviour
{
    public GameObject Currentobject;

    public Teams teams;

    public Transform _camera;

    public int Gold = 0;

    public bool ChoiceObject(GameObject gameObject, Teams _team) //��� ������ ������
    {
        if ((Currentobject == null || Currentobject != gameObject) && _team == teams)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ControlObject(GameObject gameObject) //��� ���������� 
    {
        if (Currentobject == gameObject)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void PlusObject(GameObject gameObject) //����� �������
    {
        Currentobject = gameObject;
    }
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}

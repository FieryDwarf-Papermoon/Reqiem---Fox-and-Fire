using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDirector<T> : MonoBehaviour where T : MonoBehaviour
{

    public Transform _camera;
    public Players players;

    public T Selects;

    

    public List<T> T_List = new List<T>();

    public List<T> T_List_Players = new List<T>();

    protected const float DOUBLE_CLICK_Time = 0.3f;

    protected float last_CLICK_Time;


    protected void Awake()
    {
        T_List = new List<T>();
    }

    public void Register(T T_OBG)
    {
        T_List.Add(T_OBG);
    }

    public void UnRegister(T T_OBG)
    {
        if (T_List.Contains(T_OBG))
        {
            T_List.Remove(T_OBG);
        }
    }

    public void MouseClickObgect(T T_OBG)
    {

    }

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHeries : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("R");
    }

    TypeDirectorHeroes DirectorHeroes;
    void Start()
    {
        DirectorHeroes = GameObject.FindGameObjectWithTag("DirectorHeroes").GetComponent<TypeDirectorHeroes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMove : MonoBehaviour
{
    public Text text;

    [SerializeField] private int days;

    public void NewMove()
    {
        days++;
        text.text = "MOVE: " + days;
    }

    // Start is called before the first frame update
    void Start()
    {
        days = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

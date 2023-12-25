using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGold : MonoBehaviour
{
    [SerializeField] private Players players;

    [SerializeField] private Text text;
    public void UpdateGold()
    {
        text.text = "" + players.Gold;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    //add a log with recent player moves
    //https://answers.unity.com/questions/508268/i-want-to-create-an-in-game-log-which-will-print-a.html
    public Dropdown modeSelector;
    public GameObject turnController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModeChanged(Dropdown dropdown)
    {
        Debug.Log("DROP DOWN CHANGED -> " + dropdown.value);
        string mode = dropdown.options[dropdown.value].text;
        turnController.GetComponent<TurnController>().mode = mode;
    }

    public void updatePanel(){
        //current player
        //turnController.GetComponent<TurnController>().activePlayerColor = mode;
        //player score
        //player turn
        //player pieces
        //spaces left
        //player score
        //most control
        //second most
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject turnController;
    private TurnController turnControllerScript;
    void Start()
    {
        turnControllerScript = turnController.GetComponent<TurnController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callMakeMove(){
        //turnControllerScript.makeMove();
    }
}

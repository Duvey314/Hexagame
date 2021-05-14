using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexagonController : MonoBehaviour
{

    // Set the grid values
    public int X;
    public int Y;
    public int Z;
    // Canvas Values
    public Text hexagonSelected;
    //private Text hexagonSelectedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log($"Mouse is over {X},{Y},{Z}");
        GameObject panel = GameObject.Find("Panel");
        hexagonSelected = panel.transform.Find("Hexagon_Selected").GetComponent<Text>();
        hexagonSelected.text = $"Mouse is over {X},{Y},{Z}";
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}


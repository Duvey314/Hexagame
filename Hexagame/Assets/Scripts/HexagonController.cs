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
    public GameObject turnController;
    public int stackSize = 0;

    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;
    //private Text hexagonSelectedText;
    // Start is called before the first frame update
    void Start()
    {
        turnController = GameObject.Find("Turn Controller");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        GameObject panel = GameObject.Find("Game Info Panel");
        
        hexagonSelected = panel.transform.Find("Coordinate Text").GetComponent<Text>();
        hexagonSelected.text = $"{X},{Y},{Z}";
        
        Text stackSizeText = panel.transform.Find("Stack Text").GetComponent<Text>();
        stackSizeText.text = $"Stack Size: {stackSize}";
        
        string playerColor = turnController.GetComponent<TurnController>().activePlayerColor;
        Text turnText = panel.transform.Find("Turn Text").GetComponent<Text>();
        turnText.text = $"Player Turn: {playerColor}";

        Dictionary<string, int> piecesLeftDict = turnController.GetComponent<TurnController>().playerPieceCount;
        int piecesLeft = piecesLeftDict[playerColor];
        Text pieceCountText = panel.transform.Find("Player Pieces Text").GetComponent<Text>();
        pieceCountText.text = $"Pieces Left: {piecesLeft}";
        
        //string mode = modeObject.options[Dropdown.value].text;
        // Debug.Log($"Mode: {mode}");
    }

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        if (stackSize < 3){
            stackSize++;
            Debug.Log($"StackSize: {stackSize}");
        string playerColor = turnController.GetComponent<TurnController>().activePlayerColor;
        if (playerColor == "red"){
           GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
        }
        else if (playerColor == "blue"){
           GetComponent<Renderer>().material.SetColor("_Color", Color.blue); 
        }
        else if (playerColor == "green"){
           GetComponent<Renderer>().material.SetColor("_Color", Color.green); 
        }
        else if (playerColor == "yellow"){
           GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
        }
        else{
            GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            Debug.Log("Unknown Player and Color");
        }
        
        turnController.GetComponent<TurnController>().EndTurn();
        }
        else{
            Debug.Log("Stack Full");
       }
    }
    // void OnMouseExit()
    // {
    //     //The mouse is no longer hovering over the GameObject so output this message each frame
    //     Debug.Log("Mouse is no longer on GameObject.");
    // }
}


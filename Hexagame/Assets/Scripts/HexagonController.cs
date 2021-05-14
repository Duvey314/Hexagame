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
    public string topColor;
    // Canvas Values
    public Text hexagonSelected;
    public GameObject turnController;
    public GameObject gridController;
    public int stackSize = 0;
    private string mode;

    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;
    //private Text hexagonSelectedText;
    // Start is called before the first frame update
    void Start()
    {
        turnController = GameObject.Find("Turn Controller");
        mode = turnController.GetComponent<TurnController>().mode;

        gridController = GameObject.Find("HexGrid");
        topColor = "white";
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

        Dictionary<string, int> playerScoreDict = turnController.GetComponent<TurnController>().playerScore;
        int score = playerScoreDict[playerColor];
        Text scoreText = panel.transform.Find("Player Score Text").GetComponent<Text>();
        scoreText.text = $"Player Score: {score}";

        //string mode = modeObject.options[Dropdown.value].text;
        //Debug.Log($"Mode: {mode}");
    }

    void OnMouseDown()
    {
        string playerColor = turnController.GetComponent<TurnController>().activePlayerColor;
        mode = turnController.GetComponent<TurnController>().mode;
        if (mode == "Place")
        {
            // check to see if the stack is full
            if (stackSize < 3)
            {
                stackSize++;
                //Debug.Log($"StackSize: {stackSize}");
                topColor = playerColor;
                if (playerColor == "red")
                {
                    GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                }
                else if (playerColor == "blue")
                {
                    GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                }
                else if (playerColor == "green")
                {
                    GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                }
                else if (playerColor == "yellow")
                {
                    GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                }
                else
                {
                    GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    Debug.Log("Unknown Player and Color");
                }
                turnController.GetComponent<TurnController>().DeductActivePlayerPiece();
                turnController.GetComponent<TurnController>().EndTurn();
            }
            else
            {
                Debug.Log("Stack Full");
            }
        }
        else if (mode == "Attack")
        {
            // check the number of tiles surrounding
            if (playerColor == topColor)
            {
                Debug.Log("You cannot attack your own piece");
            }
            else
            {
                int surroundingCount = gridController.GetComponent<GridController>().GetSurroundingCount(X, Y, Z, playerColor);
                if (stackSize == 0){
                    Debug.Log("Cannot attack an empty space");
                }
                else if (stackSize > 0)
                {
                    if (surroundingCount == 0)
                    {
                        Debug.Log("You have no pieces surrounding");
                    }
                    else if (surroundingCount > 0)
                    {
                        int diceRoll = Random.Range(1, 7);
                        Debug.Log("You rolled a " + diceRoll);
                        if (diceRoll <= surroundingCount)
                        {
                            turnController.GetComponent<TurnController>().AddPoints(stackSize, playerColor);
                            Debug.Log("You captured the space and gained " + stackSize + " points");
                            stackSize = 0;
                            GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                            topColor = "white";
                        }
                        else
                        {
                            Debug.Log("You did not capture the space");
                        }
                        turnController.GetComponent<TurnController>().EndTurn();
                    }
                }
                // Debug.Log(surroundingCount + " Surounding");
                // if they have 0 then say "you cannot do this"
                // if the have 1+ generate a rondom number between 1 and 6
                // if they have more than the number add the stack size to their score
                // else just end turn
            }
        }
    }

    // void OnMouseExit()
    // {
    //     //The mouse is no longer hovering over the GameObject so output this message each frame
    //     Debug.Log("Mouse is no longer on GameObject.");
    // }
}


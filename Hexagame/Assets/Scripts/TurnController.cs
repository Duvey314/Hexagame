using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public string[] players = {};
    public Dictionary<string, int> playerPieceCount = new Dictionary<string, int>();
    public Dictionary<string, int> playerScore = new Dictionary<string, int>();
    public Dictionary<string, int> playerSpaceControl = new Dictionary<string, int>();
    public Dictionary<string, string> playerType = new Dictionary<string, string>();
    public int activePlayer = 0;
    public string activePlayerColor = "red";
    public int numberOfPlayers = 4;

    public bool gameOver = false;
    public string mode;
    public int piecesPerPlayer = 20;
    public Dropdown modeSelector;
    public GameObject gridController;
    public GameObject playerController;
    public PlayerController playerControllerScript;
    public GridController gridControllerScript;
    
    public GameObject[] playerArray;
    public GameObject activePlayerObject;

    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        // get mode when game starts (defaults to place)
        mode = modeSelector.options[modeSelector.value].text;
        playerControllerScript = playerController.GetComponent<PlayerController>();
        if (playerControllerScript == null)
        {
            Debug.Log("controller script is null");
        }
        gridControllerScript = gridController.GetComponent<GridController>();
        //InvokeRepeating("makeMove", 2.0f, 0.01f);
        restartButton = GameObject.Find("RestartButton");
        playerArray = GameObject.FindGameObjectsWithTag("Player");
        activePlayerObject = playerArray[0];
        numberOfPlayers = playerArray.Length;
        DistributePieces();
        //updatePlayerColorArray();
        //Debug.Log(playerArray);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver){
           if (!activePlayerObject.GetComponent<PlayerController>().humanPlayer){
            //make a move
            // Debug.Log("current player is not human");
            // activePlayerMakeMove();
            //EndTurn();
        }
        }
        
    }

    // public void updatePlayerColorArray(){
    //     foreach (GameObject player in playerArray){
    //         players.Add(player.GetComponent<PlayerController>().playerColor);
    //     }
    // }
    public void activePlayerMakeMove(){
        activePlayerObject.GetComponent<PlayerController>().autoMakeMove();
    }
    public void makeMove(((int,int,int),string) move)
    {
        Debug.Log("We pressed the button");

        //((int, int, int), string) move = playerControllerScript.chooseMove();
        GameObject hexagon = gridControllerScript.ReturnHexObject(move.Item1.Item1, move.Item1.Item2, move.Item1.Item3);
        HexagonController hexagonScript = hexagon.GetComponent<HexagonController>();
        if (move.Item2.Equals("Place"))
        {
            hexagonScript.placeHexagon(activePlayerColor);
        }
        else if (move.Item2.Equals("Attack"))
        {
            hexagonScript.attackHexagon(gridControllerScript.GetSurroundingCount(move.Item1.Item1, move.Item1.Item2, move.Item1.Item3, activePlayerColor), activePlayerColor);
        }
        else
        {
            Debug.Log("Somethings Fuckey, you tried to do an invalid move");
        }
    }

    public void DistributePieces()
    {
        foreach (GameObject player in playerArray)
        {
            Debug.Log(player.GetComponent<PlayerController>().playerColor);
            playerPieceCount.Add(player.GetComponent<PlayerController>().playerColor, piecesPerPlayer);
            playerScore.Add(player.GetComponent<PlayerController>().playerColor, 0);
            playerSpaceControl.Add(player.GetComponent<PlayerController>().playerColor, 0);
        }
    }

    public void AddPoints(int points, string player)
    {
        playerScore[player] = playerScore[player] + points;
    }
    //remove pieces function
    public void DeductActivePlayerPiece()
    {
        playerPieceCount[activePlayerColor]--;
    }
    public void EndTurn()
    {
        Debug.Log("Turn Ended");
        gridController.GetComponent<GridController>().UpdateSpacesLeft();
        CheckGameEnd();
        if (gameOver == true)
        {
            // var spacesList = gridController.GetComponent<GridController>().countSpacesControlled();
            // foreach ((string,int) score in spacesList){
            //     Debug.Log($"{score.Item1}: {score.Item2}");
            // }
            awardPointsForPosession();
            foreach(string color in playerScore.Keys){
                Debug.Log($"{color}: {playerScore[color]}");
            }
            Debug.Log(declareWinner());
        }
        else
        {
            if (activePlayer < numberOfPlayers - 1)
            {
                activePlayer++;
            }
            else
            {
                activePlayer = 0;
            }
            //change active player object to know if it's human of robot
            activePlayerObject = playerArray[activePlayer];
            activePlayerColor = activePlayerObject.GetComponent<PlayerController>().playerColor;
            
            //if player is not human, make their move
            
        }
    }

    //public CheckforValidMove
    public void CheckGameEnd()
    {
        // check number of pieces left

        if (playerPieceCount[activePlayerColor] == 0)
        {
            Debug.Log("Game Over");
            gameOver = true;
            // restartButton = GameObject.Find("RestartButton");
            // restartButton.SetActive(true);
        }

        // check if board is filled
        if (gridController.GetComponent<GridController>().spacesLeft == 0)
        {
            Debug.Log("Game Over");
            gameOver = true;
            // restartButton = GameObject.Find("RestartButton");
            // restartButton.SetActive(true);
        }
    }
    // public Dictionary<string, int> countSpacesControlled(){

    // }
    //checkwinner
    // figure out number of tiles controlled
    //add points to those players
    //put players in order of score
    //return winning player
    public void awardPointsForPosession()
    {
        var spacesList = gridController.GetComponent<GridController>().countSpacesControlled();
        // add tie handling
        playerScore[spacesList[0].Item1] =  playerScore[spacesList[0].Item1] + 2;
        playerScore[spacesList[1].Item1] =  playerScore[spacesList[1].Item1] + 1;  
    }
    public (string,int) declareWinner(){
        int topScore = -1;
        string topScorer = "";
        foreach(string color in playerScore.Keys){
            if (playerScore[color] > topScore){
                topScore = playerScore[color];
                topScorer = color;
            }
        }
        //deal with ties
        return (topScorer, topScore);
    }
    public void endGame()
    {
        //SceneManager.LoadScene("GameScene");
    }

}

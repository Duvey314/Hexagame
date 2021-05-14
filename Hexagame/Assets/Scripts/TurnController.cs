using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{           
    public string[] players = {"red","yellow","green","blue"};
    public Dictionary<string, int> playerPieceCount = new Dictionary<string, int>();
    public Dictionary<string, int> playerScore = new Dictionary<string, int>();
    public Dictionary<string, int> playerSpaceControl = new Dictionary<string, int>();
    public int activePlayer = 0;
    public string activePlayerColor = "red";
    public int numberOfPlayers = 4;
    public string mode;
    public int piecesPerPlayer = 20;
    public Dropdown modeSelector;
    public GameObject gridController;
    public GameObject playerController;
    public PlayerController playerControllerScript;
    public GridController gridControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        DistributePieces(players);
        // get mode when game starts (defaults to place)
        mode = modeSelector.options[modeSelector.value].text;
        playerControllerScript = playerController.GetComponent<PlayerController>();
        if (playerControllerScript == null){
            Debug.Log("controller script is null");
        }
        gridControllerScript = gridController.GetComponent<GridController>();

    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void makeMove(){
        Debug.Log("We pressed the button");
    
        ((int,int,int), string) move = playerControllerScript.chooseMove();
        GameObject hexagon = gridControllerScript.ReturnHexObject(move.Item1.Item1,move.Item1.Item2,move.Item1.Item3);
        HexagonController hexagonScript = hexagon.GetComponent<HexagonController>();
        if (move.Item2.Equals("Place")){
            hexagonScript.placeHexagon(activePlayerColor);
        }
        else if (move.Item2.Equals("Attack")){
            hexagonScript.attackHexagon(gridControllerScript.GetSurroundingCount(move.Item1.Item1,move.Item1.Item2,move.Item1.Item3,activePlayerColor), activePlayerColor);
        }
        else{
            Debug.Log("Somethings Fuckey, you tried to do an invalid move");
        }
    }

    public void DistributePieces(string[] playersList){
        foreach (string player in playersList){
            playerPieceCount.Add(player, piecesPerPlayer);
            playerScore.Add(player,0);
            playerSpaceControl.Add(player,0);
        }
    }

    public void AddPoints(int points, string player){
        playerScore[player] = playerScore[player] + points;
    }
    //remove pieces function
    public void DeductActivePlayerPiece(){
        playerPieceCount[activePlayerColor]--;
    }
    public void EndTurn(){
        Debug.Log("Turn Ended");
        gridController.GetComponent<GridController>().UpdateSpacesLeft();
        CheckGameEnd();
        if(activePlayer < numberOfPlayers-1){
            activePlayer++;
        }
        else{
            activePlayer = 0;
        }
        activePlayerColor = players[activePlayer];
        //Debug.Log(playerControllerScript.chooseMove());
        // update spaces left
    }
    
    //public CheckforValidMove
    public void CheckGameEnd(){
        // check number of pieces left
        if (playerPieceCount[activePlayerColor]==0){
            Debug.Log("Game Over");
        }

        // check if board is filled
        if (gridController.GetComponent<GridController>().spacesLeft == 0){
            Debug.Log("Game Over");
        }
    }
}

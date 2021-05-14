using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{           
    public string[] players = {"red","yellow","green","blue"};
    public Dictionary<string, int> playerPieceCount = new Dictionary<string, int>();
    public Dictionary<string, int> playerScore = new Dictionary<string, int>();
    public int activePlayer = 0;
    public string activePlayerColor = "red";
    public int numberOfPlayers = 4;
    public string mode;
    public int piecesPerPlayer = 20;
    public Dropdown modeSelector;
    public GameObject gridController;

    // Start is called before the first frame update
    void Start()
    {
        DistributePieces(players);
        // get mode when game starts (defaults to place)
        mode = modeSelector.options[modeSelector.value].text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DistributePieces(string[] playersList){
        foreach (string player in playersList){
            playerPieceCount.Add(player, piecesPerPlayer);
            playerScore.Add(player,0);
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
        CheckGameEnd();
        if(activePlayer < numberOfPlayers-1){
            activePlayer++;
        }
        else{
            activePlayer = 0;
        }
        activePlayerColor = players[activePlayer];
        // update spaces left
        gridController.GetComponent<GridController>().UpdateSpacesLeft();
    }
    
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

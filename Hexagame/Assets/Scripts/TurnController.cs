using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{           
    public string[] players = {"red","yellow","green","blue"};
    public Dictionary<string, int> playerPieceCount = new Dictionary<string, int>();
    public int activePlayer = 0;
    public string activePlayerColor = "red";
    public int numberOfPlayers = 4;
    public string mode = "singleHexagon";
    public int piecesPerPlayer = 20;

    // Start is called before the first frame update
    void Start()
    {
        DistributePieces(players);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DistributePieces(string[] playersList){
        foreach (string player in playersList){
            playerPieceCount.Add(player, piecesPerPlayer);
        }
    }

    public void EndTurn(){
        playerPieceCount[activePlayerColor]--;

        Debug.Log(playerPieceCount[activePlayerColor]);
        if(activePlayer < numberOfPlayers-1){
            activePlayer++;
        }
        else{
            activePlayer = 0;
        }
        activePlayerColor = players[activePlayer];
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject turnController;
    public GameObject gridController;
    public bool humanPlayer = false;
    public string playerColor; 
    private GridController gridControllerScript;
    private TurnController turnControllerScript;
    
    
      
    void Start()
    {
        gridControllerScript = gridController.GetComponent<GridController>();
        turnControllerScript = turnController.GetComponent<TurnController>();
        // DontDestroyOnLoad(transform.gameObject);
        // var rand = new Random();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public List<((int,int,int),string)> generateMoves(){
        // find grid object dynamically
        List<GameObject> hexagonGridList = gridControllerScript.hexagonGridList;
        List<((int,int,int),string)> possibleMoves = new List<((int,int,int),string)>();
        foreach(GameObject hexagonObject in hexagonGridList){
            HexagonController hexagon = hexagonObject.GetComponent<HexagonController>(); 
            if (!hexagon.topColor.Equals(turnControllerScript.activePlayerColor)){
                if (hexagon.stackSize>0 && 
                gridControllerScript.GetSurroundingCount(hexagon.X, hexagon.Y, hexagon.Z, turnControllerScript.activePlayerColor)>0){
                    possibleMoves.Add(((hexagon.X, hexagon.Y, hexagon.Z),"Attack"));
                }
                if (hexagon.stackSize<3){
                    possibleMoves.Add(((hexagon.X, hexagon.Y, hexagon.Z),"Place"));
                }
            }
        }
        return possibleMoves;
    }
    
    public ((int,int,int),string) chooseMove(){
        List<((int,int,int),string)> possibleMoves = generateMoves();
        int index = Random.Range(0, possibleMoves.Count);
        ((int,int,int),string) move = possibleMoves[index];
        return move;
    }
    public void autoMakeMove(){
        ((int, int, int), string) move = chooseMove();
        turnControllerScript.makeMove(move);
    }
    public void makeMove(((int,int,int),string) move){
        //call make move function
        turnControllerScript.makeMove(move);
        //move.Item1.Item1, move.Item1.Item2, move.Item1.Item3
    }
    //public void  { pass in board
        
        // iterate through list of hexagone
        // for each hexagon, see if it's full
        // //see if top color is not your color
        // 
        // //is top color yours?
        // is it empty
        // do you have any pieces adjacent 
        //
        // add location and move to dict
        // 
        // randomly choose move and return
        // List<((int,int,int),string)> possibleMoves = new List<((int,int,int),string)>();
        // possibleMoves.Add(((1,-1,0),"place"));
        // Debug.Log(possibleMoves[0].Item1); 
}

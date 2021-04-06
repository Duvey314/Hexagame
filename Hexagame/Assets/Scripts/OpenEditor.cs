using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenEditor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    private Text gridSizeText;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }  
    public void OnButtonPress() 
    {  
        if (Panel != null) {  
            bool isActive = Panel.activeSelf;  
            if (isActive)
            {
                gameObject.GetComponentInChildren<Text>().text = "Open Editor";
            }
            else
            {
                gameObject.GetComponentInChildren<Text>().text = "Close Editor";
            }
            Panel.SetActive(!isActive);  
        }
        GameObject Grid = GameObject.Find("HexGrid");
        GridController gridController = Grid.GetComponent<GridController>();

        gridSizeText = GameObject.Find("Grid_Size_Text").GetComponent<Text>(); 
        
        int gridSize = gridController.gridSize; 
        gridSizeText.text = $"Grid Size: {gridSize}";
    }


}

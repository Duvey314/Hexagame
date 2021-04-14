using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public int gridSize = 5;
    public float hexSize = 1;
    public GameObject gridHexagonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        Debug.Log("Program Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        Debug.Log("Generating Grid");
        int[] grid;
        GameObject hexagon;
        for (int x = -gridSize; x < gridSize+1; x++) 
        {
            for (int y = -gridSize; y < gridSize+1; y++) 
            {
                for (int z = -gridSize; z < gridSize+1; z++) 
                {
                    if (x+y+z == 0)
                    {
                        Debug.Log($"Element added at: {x},{y},{z}");
                        if(x==0 & y == 0 & x == 0)
                        {
                            hexagon = Instantiate(gridHexagonPrefab, new Vector2(0,0), Quaternion.identity);
                            hexagon.GetComponent<HexagonController>().X = x;
                            hexagon.GetComponent<HexagonController>().Y = y;
                            hexagon.GetComponent<HexagonController>().Z = z;
                        }

                        else
                        {
                            float centX = hexSize * (Convert.ToSingle(Math.Sqrt(3)) * Convert.ToSingle(x) + Convert.ToSingle(Math.Sqrt(3) / 2) * Convert.ToSingle(z));
                            float centY = hexSize * (Convert.ToSingle(3.0 / 2) * Convert.ToSingle(z));
                            hexagon = Instantiate(gridHexagonPrefab, new Vector2(centX,centY), Quaternion.identity);
                            hexagon.GetComponent<HexagonController>().X = x;
                            hexagon.GetComponent<HexagonController>().Y = y;
                            hexagon.GetComponent<HexagonController>().Z = z;
                            
                        }
                    }
                }
            }
        }

    }

    // public GameObject[] GetNeighbors(int x, int y, int z)
    // {
    //     new GameObject[] hexNeighbors;
    //     return hexNeighbors;
    // }
    public GameObject ReturnHexObject(int x, int y, int z){
        
    }
        
}


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
                        //Debug.Log($"Element added at: {x},{y},{z}");
                        if(x==0 & y == 0 & x == 0)
                        {
                            // Create the hexagon and set it's center to be the center (0,0)
                            hexagon = Instantiate(gridHexagonPrefab, new Vector2(0,0), Quaternion.identity);
                            
                            // Set the hexgrid as the parent of the hexagon
                            hexagon.transform.parent = transform;
                            
                            // Set the grid coordinates of the hexagon
                            hexagon.GetComponent<HexagonController>().X = x;
                            hexagon.GetComponent<HexagonController>().Y = y;
                            hexagon.GetComponent<HexagonController>().Z = z;
                           
                            
                        }

                        else
                        {
                            // Set the location of the hexagon
                            float centX = hexSize * (Convert.ToSingle(Math.Sqrt(3)) * Convert.ToSingle(x) + Convert.ToSingle(Math.Sqrt(3) / 2) * Convert.ToSingle(z));
                            float centY = hexSize * (Convert.ToSingle(3.0 / 2) * Convert.ToSingle(z));

                            // Create the hexagon and set it's center from above
                            hexagon = Instantiate(gridHexagonPrefab, new Vector2(centX,centY), Quaternion.identity);
                            
                            // Set the hexgrid as the parent of the hexagon
                            hexagon.transform.parent = transform;

                            // Set the grid coordinates of the hexagon
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
    public GameObject ReturnHexObject(int x, int y, int z)
    {
        foreach(Transform child in transform)
        {
            GameObject hexagon = child.gameObject;
            
            int xCoord = hexagon.GetComponent<HexagonController>().X;
            int yCoord = hexagon.GetComponent<HexagonController>().Y;
            int zCoord = hexagon.GetComponent<HexagonController>().Z;

            if (xCoord == x && yCoord == y && zCoord == z)
            {
                return hexagon;
            }
            else
            {
                Debug.Log("Hex not a match");
            }
        }
    return new GameObject();
    }

    public void GetNeighbors(int x, int y, int z){
        
        List<GameObject> cubeNeighbors = new List<GameObject>();

        int[,] cubeDirections = new int[,] { {1, -1, 0}, {1, 0, -1}, {0, 1, -1}, 
                                        {-1, 1, 0}, {-1, 0, 1}, {0, -1, 1} };
        
        for (int i = 0; i < cubeDirections.GetLength(0); i++)
        {
            int xCoord = cubeDirections[i,0] + x;
            int yCoord = cubeDirections[i,1] + y;
            int zCoord = cubeDirections[i,2] + z;
            GameObject neighboringHexagon = ReturnHexObject(xCoord, yCoord, zCoord);
            
            // hexagonRender = neighboringHexagon.GetComponent<Renderer>();
            //Get the Renderer component from the new cube
            neighboringHexagon.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        
            cubeNeighbors.Add(neighboringHexagon);
        }

        Debug.Log(cubeNeighbors);

        // for direction in cube_directions:
        //     neighbor = grid.ret_hex_cube(x+direction[0],y+direction[1],z+direction[2])
        //     neighbors.append(neighbor)
        // return(neighbors)

    }

    public void PlaceHexagon(int x, int y, int z){
        
    }
        
}


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
                            Instantiate(gridHexagonPrefab, new Vector2(0,0), Quaternion.identity);
                        }

                        else
                        {
                            float centX = hexSize * (Convert.ToSingle(Math.Sqrt(3)) * Convert.ToSingle(x) + Convert.ToSingle(Math.Sqrt(3) / 2) * Convert.ToSingle(z));
                            float centY = hexSize * (Convert.ToSingle(3.0 / 2) * Convert.ToSingle(z));
                            Instantiate(gridHexagonPrefab, new Vector2(centX,centY), Quaternion.identity);
                            
                        }
                    }
                }
            }
        }

    }
}
    // public void DrawGrid()
    // {

    // # need the . in 3/2 to make 3.0/2
    //     if (self.x == 0 and self.y == 0 and self.z == 0):
    //         self.centx = self.canvas_width / 2
    //         self.centy = self.canvas_height / 2
    //         print("one")
    //     else:
    //         print("two")
    //         if self.rot == 'flat':
    //             self.centx = (self.size * ((3.0 / 2) * self.x)) + (self.canvas_width / 2)
    //             self.centy = (self.size * ((math.sqrt(3) / 2) * self.x + math.sqrt(3) * self.z)) + (self.canvas_height / 2)
    //         elif self.rot == 'pointy':
    //             self.centx = (self.size * (math.sqrt(3) * self.x + math.sqrt(3) / 2 * self.z)) + (self.canvas_height / 2)
    //             self.centy = (self.size * ((3.0 / 2) * self.z)) + (self.canvas_width / 2)    
    // }


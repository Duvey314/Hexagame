using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatePlayers : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject redPlayerToggle;
    private GameObject bluePlayerToggle;
    private GameObject greenPlayerToggle;
    private GameObject yellowPlayerToggle;
    public GameObject playerPrefab;
    void Start()
    {
        redPlayerToggle = GameObject.Find("Red Player Toggle");
        bluePlayerToggle = GameObject.Find("Blue Player Toggle");
        greenPlayerToggle = GameObject.Find("Green Player Toggle");
        yellowPlayerToggle = GameObject.Find("Yellow Player Toggle");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createPlayers()
    {
        if (redPlayerToggle.GetComponent<Toggle>().isOn)
        {
            Dropdown playerTypeSelector = redPlayerToggle.transform.Find("Player Type Dropdown").GetComponent<Dropdown>();
            string playerType = playerTypeSelector.options[playerTypeSelector.value].text;
            
            GameObject player = Instantiate(playerPrefab, new Vector2(10, 10), Quaternion.identity);
            PlayerController playerControllerScript = player.GetComponent<PlayerController>();
            
            playerControllerScript.playerColor = "red";

            Debug.Log($"Red player is {playerType}");
            if (playerType.Equals("Human"))
            {
                playerControllerScript.humanPlayer = true;
            }
            else if (playerType.Equals("Computer"))
            {
                playerControllerScript.humanPlayer = false;
            }

        }
         if (bluePlayerToggle.GetComponent<Toggle>().isOn)
        {
            Dropdown playerTypeSelector = bluePlayerToggle.transform.Find("Player Type Dropdown").GetComponent<Dropdown>();
            string playerType = playerTypeSelector.options[playerTypeSelector.value].text;
            
            GameObject player = Instantiate(playerPrefab, new Vector2(0, 0), Quaternion.identity);
            PlayerController playerControllerScript = player.GetComponent<PlayerController>();
            
            playerControllerScript.playerColor = "blue";

            Debug.Log($"Blue player is {playerType}");
            if (playerType.Equals("Human"))
            {
                playerControllerScript.humanPlayer = true;
            }
            else if (playerType.Equals("Computer"))
            {
                playerControllerScript.humanPlayer = false;
            }

        }
        if (greenPlayerToggle.GetComponent<Toggle>().isOn)
        {
            Dropdown playerTypeSelector = greenPlayerToggle.transform.Find("Player Type Dropdown").GetComponent<Dropdown>(); ;
            string playerType = playerTypeSelector.options[playerTypeSelector.value].text;
            
            GameObject player = Instantiate(playerPrefab, new Vector2(0, 0), Quaternion.identity);
            PlayerController playerControllerScript = player.GetComponent<PlayerController>();
            
            playerControllerScript.playerColor = "green";

            Debug.Log($"green player is {playerType}");
            if (playerType.Equals("Human"))
            {
                playerControllerScript.humanPlayer = true;
            }
            else if (playerType.Equals("Computer"))
            {
                playerControllerScript.humanPlayer = false;
            }

        }
        if (yellowPlayerToggle.GetComponent<Toggle>().isOn)
        {
            Dropdown playerTypeSelector = yellowPlayerToggle.transform.Find("Player Type Dropdown").GetComponent<Dropdown>(); ;
            string playerType = playerTypeSelector.options[playerTypeSelector.value].text;
            
            GameObject player = Instantiate(playerPrefab, new Vector2(0, 0), Quaternion.identity);
            PlayerController playerControllerScript = player.GetComponent<PlayerController>();
            
            playerControllerScript.playerColor = "yellow";

            Debug.Log($"yellow player is {playerType}");
            if (playerType.Equals("Human"))
            {
                playerControllerScript.humanPlayer = true;
            }
            else if (playerType.Equals("Computer"))
            {
                playerControllerScript.humanPlayer = false;
            }

        }
        SceneManager.LoadScene("GameScene");
        // need to be able to save all the players , not just one
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInstantiate : MonoBehaviour
{
    [SerializeField] private bool isComputerActive = true; // Activity of computer
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject computerPrefab;
     private Items startItemForInstantiate; //Field for choosing start item
     private List<GameObject> computerPrefabList;
     private List<Vector3> computerPositionList;

    private InstantiateSettings instantiateSettings;
    private ItemCollision playerItemCollision;
    private int index = 0; // Index for computer smart instantiate
    // Properties 
    public bool IsComputerEndInstantiate { get; private set; } = false;
    public bool IsPlayerCanInstantiate { get; set; } = true;

    public Items StartItemForInstantiate {
        get { return startItemForInstantiate; }
    }
   

    private void Start()
    {
        // Setting computer prefabs and their positions
        instantiateSettings = FindObjectOfType<InstantiateSettings>();

        startItemForInstantiate = instantiateSettings.StartItemForInstantiate;
        computerPrefabList = instantiateSettings.ComputerPrefabList;
        computerPositionList = instantiateSettings.ComputerPositionList;


        // Choosing start item
        switch (startItemForInstantiate)
        {
            case Items.blueCube:
                SetBlueColour();
                break;
            case Items.redCube:
                SetRedColour();
                break;
            case Items.sheep:
                SetSheep(true);
                break;
            case Items.mouse:
                SetMouse(true);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        // Mouse input
        if (IsPlayerCanInstantiate && Input.GetButtonDown("Fire1") && Input.mousePosition.x < Screen.width / 2)
        {
            
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 2.0f;       
            Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            GameObject clone = Instantiate(playerPrefab, objectPosition, Quaternion.identity);
            clone.tag = "Player";

            // Activity of computer dealing with prefabs
            playerItemCollision = clone.GetComponent<ItemCollision>();
            playerItemCollision.SetComputerActive(isComputerActive);
            
        }

        
    }
 
    // Change prefab (red)
    public void SetCharacter(Items character)
    {
        string characterName = character.ToString();
        playerPrefab = (GameObject)Resources.Load("Prefabs/" + characterName, typeof(GameObject));
    }
    public void SetRedColour()
    {
        playerPrefab = (GameObject)Resources.Load("Prefabs/RedCube", typeof(GameObject));

    }
    // Change prefab (blue)
    public void SetBlueColour()
    {
        playerPrefab = (GameObject)Resources.Load("Prefabs/BlueCube", typeof(GameObject));
        
    }

    public void SetSheep(bool changeValue)
    {
        playerPrefab = (GameObject)Resources.Load("Prefabs/Sheep", typeof(GameObject));
    }

    public void SetMouse(bool changeValue)
    {
        playerPrefab = (GameObject)Resources.Load("Prefabs/Mouse", typeof(GameObject));
    }

    // Computer turn
    public void OldComputerIntantiate()
    {
        GameObject clone = Instantiate(computerPrefab, new Vector3(3, 5, 0), Quaternion.identity);
        clone.tag = "Computer";
        
    }

    // Computer smart isntantiate
    public void ComputerInstantiate()
    {
        
        if (computerPrefabList.Count != computerPositionList.Count)
        {
            print("Error: Add values to both lists");
            return;
            
        }
        if (index == computerPrefabList.Count)
        {
            IsComputerEndInstantiate = true;
            return;
        }
        GameObject prefab = computerPrefabList[index];
        Vector3 position = computerPositionList[index];

        GameObject clone = Instantiate(prefab, position, Quaternion.identity);
        clone.tag = "Computer";

        
        index++;
    }

    


}

// All characters in game
public enum Items
{
    blueCube,
    redCube,
    sheep,
    mouse
}


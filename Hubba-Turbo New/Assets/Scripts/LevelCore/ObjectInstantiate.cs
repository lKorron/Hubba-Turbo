using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInstantiate : MonoBehaviour
{
    private GameObject playerPrefab;

    private List<GameObject> computerPrefabList = new List<GameObject>();
    private List<Vector3> computerPositionList = new List<Vector3>();
    private List<int> instantiateNumberList = new List<int>();

    private InstantiateSettings instantiateSettings;
    private int index = 0; // Index for computer smart instantiate
    // Properties 
    public bool IsComputerEndInstantiate { get; private set; } = false;
    public bool IsPlayerCanInstantiate { get; set; } = true;

    private void Start()
    {
        // Setting computer prefabs and their positions
        instantiateSettings = FindObjectOfType<InstantiateSettings>();
        SetItems();
    }

    private void Update()
    {
        ClickProcessing();
    }
 
    // Change prefab (red)
    public void SetCharacter(Animal character)
    {
        string characterName = character.ToString();
        playerPrefab = (GameObject)Resources.Load("Prefabs/" + characterName, typeof(GameObject));
    }

    // Computer smart isntantiate
    public void ComputerInstantiate()
    {
        if (computerPrefabList.Count != computerPositionList.Count)
            throw new MissingComponentException("Error: Add values to both lists");

        if (index == computerPrefabList.Count)
        {
            IsComputerEndInstantiate = true;
            return;
        }

        GameObject prefab = computerPrefabList[index];
        Vector3 position = computerPositionList[index];
        int instantiateNumber = instantiateNumberList[index];

        if (instantiateNumber == 0)
            Instantiate(prefab, position, Quaternion.identity);
        else
        {
            for (int i = 0; i < instantiateNumber; i++)
                Instantiate(prefab, position, Quaternion.identity);
            
        }
        
        index++;
    }

    public void CheckComputerEndInstantiate()
    {
        if (index == computerPrefabList.Count)
        {
            IsComputerEndInstantiate = true;
            return;
        }
    }

    private void SetItems()
    {
        var instantiateItems = instantiateSettings.InstantiateItems;
        if (instantiateItems != null)
        {
            foreach (var item in instantiateItems)
            {
                computerPrefabList.Add(item.Prefab);
                computerPositionList.Add(item.Position);
                instantiateNumberList.Add(item.PrefabsNumber);
            }
        }
    }

    private void ClickProcessing()
    {
        // Mouse input
        if (IsPlayerCanInstantiate && Input.GetButtonDown("Fire1") && Input.mousePosition.x < Screen.width / 2)
        {

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 2.0f;
            Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            GameObject clone = Instantiate(playerPrefab, objectPosition, Quaternion.identity);
        }
    }
}




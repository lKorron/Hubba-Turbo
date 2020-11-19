using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInstantiate : MonoBehaviour
{
    [SerializeField] private Control _control;

    private List<GameObject> _computerPrefabList = new List<GameObject>();
    private List<Vector3> _computerPositionList = new List<Vector3>();
    private List<int> _instantiateNumberList = new List<int>();
    private InstantiateSettings _instantiateSettings;
    private GameObject _playerPrefab;
    private int _index = 0; // Index for computer smart instantiate
    // Properties 
    public bool IsComputerEndInstantiate { get; private set; } = false;
    public bool IsPlayerCanInstantiate { get; set; } = true;

    private void Start()
    {
        // Setting computer prefabs and their positions
        _instantiateSettings = FindObjectOfType<InstantiateSettings>();
        SetItems();
    }

    private void Update()
    {
        if (_control == Control.Mouse)
            ClickProcessing();
        if (_control == Control.Touch)
            TouchProcessing();
    }
 
    // Change prefab (red)
    public void SetCharacter(Animal character)
    {
        string characterName = character.ToString();
        _playerPrefab = (GameObject)Resources.Load("Prefabs/" + characterName, typeof(GameObject));
    }

    // Computer smart isntantiate
    public void ComputerInstantiate()
    {
        if (_computerPrefabList.Count != _computerPositionList.Count)
            throw new MissingComponentException("Error: Add values to both lists");

        if (_index == _computerPrefabList.Count)
        {
            IsComputerEndInstantiate = true;
            return;
        }

        GameObject prefab = _computerPrefabList[_index];
        Vector3 position = _computerPositionList[_index];
        int instantiateNumber = _instantiateNumberList[_index];

        if (instantiateNumber == 0)
            Instantiate(prefab, position, Quaternion.identity);
        else
        {
            for (int i = 0; i < instantiateNumber; i++)
                Instantiate(prefab, position, Quaternion.identity);
            
        }
        
        _index++;
    }

    public void CheckComputerEndInstantiate()
    {
        if (_index == _computerPrefabList.Count)
        {
            IsComputerEndInstantiate = true;
            return;
        }
    }

    private void SetItems()
    {
        var instantiateItems = _instantiateSettings.InstantiateItems;
        if (instantiateItems != null)
        {
            foreach (var item in instantiateItems)
            {
                _computerPrefabList.Add(item.Prefab.gameObject);
                _computerPositionList.Add(item.Position);
                _instantiateNumberList.Add(item.PrefabsNumber);
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
            GameObject clone = Instantiate(_playerPrefab, objectPosition, Quaternion.identity);
        }
    }

    private void TouchProcessing()
    {
        if (Input.touchCount > 0 && Input.touches[0].position.x < Screen.width / 2)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = touch.position;
            Vector3 objectPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            GameObject clone = Instantiate(_playerPrefab, objectPosition, Quaternion.identity);
        }
    }
}




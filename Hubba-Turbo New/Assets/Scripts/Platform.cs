using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool IsComputerActive = true; // Field determines will computer get turn or not
    [SerializeField] private UnityEvent OnCollision; // Event for computer instantiate
    [SerializeField] private ObjectInstantiate objectInstantiate; // Instance for check computer activity
    private WeightComparing weightComparing; // Instance for comparing
    

    private void Start()
    {
        weightComparing = GetComponent<WeightComparing>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        // Processing collision with tag
        switch (collision.gameObject.tag)
        { 
            case "PlayerStart":
                SetItem(collision, Side.Player);
                break;
            case "Player":
                SetItem(collision, Side.Player);
                if (IsComputerActive)
                {
                    OnCollision.Invoke(); // Computer turn
                }
                else weightComparing.Compare();
                
                break;
            case "Computer":
                SetItem(collision, Side.Computer);
                weightComparing.Compare();
                break;
            
        }
        // Comparing
        if (objectInstantiate.IsComputerEndInstantiate)
        {
            weightComparing.Compare();
        }
    }

    // Adding item (collision) to instance array
    private void SetItem(Collision2D collision, Side side)
    {
        collision.gameObject.tag = "Untagged";
     
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null)
        {
            weightComparing.AddItem(item, side);
            
        }
        else print("item is null");
    }

    

    
}

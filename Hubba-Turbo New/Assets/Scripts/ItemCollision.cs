using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollision : MonoBehaviour
{
    [SerializeField] private bool IsComputerActive = true; // Field determines will computer get turn or not
    //[SerializeField] private UnityEvent OnPlayerCollisionWithOther;
    [SerializeField] private WeightComparing weightComparing;
    private ObjectInstantiate objectInstantiate;

    private void Start()
    {
        weightComparing = GameObject.FindGameObjectWithTag("Platform").GetComponent<WeightComparing>();
        objectInstantiate = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ObjectInstantiate>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.tag = "Untagged";
            OnPlayerCollisionWithOther.Invoke();
        } */
        //Item item = collision.gameObject?.GetComponent<Item>();

        switch (collision.gameObject.tag)
        {
            case "PlayerStart":
                SetItem(collision, Side.Player);
                break;
            case "Player":
                collision.gameObject.tag = "Untagged";
                SetItem(collision, Side.Player);
                if (IsComputerActive)
                {
                    
                    objectInstantiate.ComputerInstantiate();
                }
                else weightComparing.Compare();
                
                
                break;
            case "Computer":
                SetItem(collision, Side.Computer);
                weightComparing.Compare();
                break;
            default:
                break;
        }
        // Comparing
        if (objectInstantiate.IsComputerEndInstantiate)
        {
            weightComparing.Compare();
        }
        

    }
    // Setting computer activity from outside
    public void SetComputerActive(bool isActive)
    {
        IsComputerActive = isActive;
    }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeightComparing : MonoBehaviour
{
    private HingeJoint2D hingeJoint2d; // Use for SetBalance() method
    [SerializeField] private UnityEvent playerWin;

    // Arrays for game items

    [SerializeField] private List<Item> playerItems = new List<Item>();
    [SerializeField] private List<Item> computerItems = new List<Item>();

    private void Start()
    {
        hingeJoint2d = GetComponent<HingeJoint2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print(IsMouseAndElephant());
        }
    }

    // Add item to chosen array
    public void AddItem(Item item, Side side)
    {
        switch (side)
        {
            case Side.Player:
                playerItems.Add(item);
                break;
            case Side.Computer:
                computerItems.Add(item);
                break;
            default:
                break;
        }
    }

    public void Compare()
    {
        int playerWeight = 0;
        int computerWeight = 0;

        for (int i = 0; i < playerItems.Count; i++)
        {
            if (playerItems[i] != null)
            {
                playerWeight += playerItems[i].Weight;
            }
            
            
            
        }

        for (int i = 0; i < computerItems.Count; i++)
        {
            if (computerItems[i] != null)
            {
                computerWeight += computerItems[i].Weight;
            }
            
        }

        if (playerWeight == computerWeight && playerWeight > 0 && computerWeight > 0)
        {
            SetBalance();
            playerWin.Invoke();
        }
    }

    // Checks are mouse and elephant together on board
    public bool IsMouseAndElephant()
    {
        bool isMouse = false;
        bool isElephant = false;

        foreach (var item in playerItems)
        {
            if (item != null)
            {
                switch (item.gameObject.name)
                {
                    case "Mouse":
                        isMouse = true;
                        break;
                    case "Mouse(Clone)":
                        isMouse = true;
                        break;
                    case "Elephant":
                        isElephant = true;
                        break;
                    case "Elephant(Clone)":
                        isElephant = true;
                        break;
                    default:
                        break;
                }
            }
            
        }

        foreach (var item in computerItems)
        {
            if (item != null)
            {
                switch (item.gameObject.name)
                {
                    case "Mouse":
                        isMouse = true;
                        break;
                    case "Elephant":
                        isElephant = true;
                        break;
                    default:
                        break;
                }
            }
            
        }

        return isMouse && isElephant;
    }

    // May be 
    private void UseMotor()
    {
        JointMotor2D motor = new JointMotor2D();
        motor.motorSpeed = 100;
        motor.maxMotorTorque = 1f;
        hingeJoint2d.motor = motor;
    }

    // Turn platform into balance state
    public void SetBalance()
    {
        JointAngleLimits2D limits = new JointAngleLimits2D();
        limits.min = 0f;
        limits.max = 0f;
        hingeJoint2d.limits = limits;
    }
}

// Enum for comfortable 
public enum Side
{
    Player,
    Computer

}

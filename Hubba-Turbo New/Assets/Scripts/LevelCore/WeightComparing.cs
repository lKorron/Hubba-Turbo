using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeightComparing : MonoBehaviour
{
    private HingeJoint2D hingeJoint2d; // Use for SetBalance() method
    private UnityEvent playerWin;

    // Arrays for game items

    [SerializeField] private List<Item> playerItems = new List<Item>();
    [SerializeField] private List<Item> computerItems = new List<Item>();

    private Win winGameObject;

    private void Start()
    {
        hingeJoint2d = GetComponent<HingeJoint2D>();
        winGameObject = Resources.FindObjectsOfTypeAll<Win>()[0];

        if (playerWin == null)
        {
            playerWin = new UnityEvent();
        }
        playerWin.AddListener(winGameObject.PlayerWin);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print(IsMouseAndElephant(Animal.Mouse, Animal.Elephant));
        }
    }

    private void OnDisable()
    {
        playerWin.RemoveAllListeners();
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
    public bool IsMouseAndElephant(Animal firstAnimal, Animal secondAnimal)
    {
        bool isFirstAnimal = false;
        bool isSecondAnimal = false;

        foreach (var item in playerItems)
        {
            if (item != null)
            {
                if (item.gameObject.name == firstAnimal.ToString())
                {
                    isFirstAnimal = true;
                }
                if (item.gameObject.name == firstAnimal.ToString() + "(Clone)")
                {
                    isFirstAnimal = true;
                }
                if (item.gameObject.name == secondAnimal.ToString())
                {
                    isSecondAnimal = true;
                }
                if (item.gameObject.name == firstAnimal.ToString() + "(Clone)")
                {
                    isSecondAnimal = true;
                }
            }
            
        }

        foreach (var item in computerItems)
        {
            if (item != null)
            {
                if (item.gameObject.name == firstAnimal.ToString())
                {
                    isFirstAnimal = true;
                }
                if (item.gameObject.name == secondAnimal.ToString())
                {
                    isSecondAnimal = true;
                }
            }
            
        }

        return isFirstAnimal && isSecondAnimal;
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

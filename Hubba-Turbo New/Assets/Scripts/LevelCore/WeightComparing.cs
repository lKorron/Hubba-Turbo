using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HingeJoint2D))]

public class WeightComparing : MonoBehaviour
{
    // Arrays for game items
    [SerializeField] private List<Item> playerItems = new List<Item>();
    [SerializeField] private List<Item> computerItems = new List<Item>();
    // For Comparing
    [SerializeField] private int playerItemsWeight = 0;
    [SerializeField] private int computerItemsWeight = 0;
    // Use for SetBalance() method
    private HingeJoint2D _hingeJoint2d; 
    private UnityEvent _playerWin;

    private Win _winInstance;

    private void Start()
    {
        _hingeJoint2d = GetComponent<HingeJoint2D>();
        _winInstance = Resources.FindObjectsOfTypeAll<Win>()[0];

        if (_playerWin == null)
        {
            _playerWin = new UnityEvent();
        }
        _playerWin.AddListener(_winInstance.PlayerWin);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print(IsAnimalsOnBoard(Animal.Mouse, Animal.Elephant));
        }
    }

    private void OnDisable()
    {
        _playerWin.RemoveAllListeners();
    }

    // Add item to chosen array
    public void AddItem(Item item, Side side)
    {
        if (side == Side.Player)
        {
            playerItems.Add(item);
            playerItemsWeight += item.Weight;
        }
        if (side == Side.Computer)
        {
            computerItems.Add(item);
            computerItemsWeight += item.Weight;
        }
    }

    // Remove item from list
    public void RemoveItem(Item item, Side side)
    {
        if (side == Side.Player)
        {
            playerItems.Remove(item);
            playerItemsWeight -= item.Weight;
        }
        if (side == Side.Computer)
        {
            computerItems.Remove(item);
            computerItemsWeight -= item.Weight;
        }
    }

    public void Compare()
    {
        if (playerItemsWeight == computerItemsWeight
            && playerItemsWeight > 0
            && computerItemsWeight > 0)
        {
            SetBalance();
            _playerWin.Invoke();
        }
    }

    // Checks are mouse and elephant together on board
    public bool IsAnimalsOnBoard(Animal fearAnimal, Animal selfAnimal)
    {
        bool isFirstAnimal = false;
        bool isSecondAnimal = false;

        foreach (var item in playerItems)
        {
            if (item != null)
            {
                if (item.gameObject.name == fearAnimal.ToString())
                {
                    isFirstAnimal = true;
                }
                if (item.gameObject.name == fearAnimal.ToString() + "(Clone)")
                {
                    isFirstAnimal = true;
                }
                if (item.gameObject.name == selfAnimal.ToString())
                {
                    isSecondAnimal = true;
                }
                if (item.gameObject.name == fearAnimal.ToString() + "(Clone)")
                {
                    isSecondAnimal = true;
                }
            }
            
        }

        foreach (var item in computerItems)
        {
            if (item != null)
            {
                if (item.gameObject.name == fearAnimal.ToString())
                {
                    isFirstAnimal = true;
                }
                if (item.gameObject.name == selfAnimal.ToString())
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
        _hingeJoint2d.motor = motor;
    }

    // Turn platform into balance state
    public void SetBalance()
    {
        JointAngleLimits2D limits = new JointAngleLimits2D();
        limits.min = 0f;
        limits.max = 0f;
        _hingeJoint2d.limits = limits;
    }
}

// Enum for comfortable 
public enum Side
{
    Player,
    Computer

}

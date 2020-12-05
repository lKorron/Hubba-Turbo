using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HingeJoint2D))]

public class WeightComparing : MonoBehaviour
{
    // Arrays for game items
    [SerializeField] private List<IItem> playerItems = new List<IItem>();
    [SerializeField] private List<IItem> computerItems = new List<IItem>();
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
    public void AddItem(IItem item, Side side)
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
    public void RemoveItem(IItem item, Side side)
    {
        if (side == Side.Player)
        {
            playerItems.Remove(item);
            playerItemsWeight -= item.Weight;
            if (playerItemsWeight < 0) playerItemsWeight = 0;
        }
        if (side == Side.Computer)
        {
            computerItems.Remove(item);
            computerItemsWeight -= item.Weight;
            if (computerItemsWeight < 0) computerItemsWeight = 0;
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
        bool isFirstAnimalInList = false;
        bool isSecondAnimal = false;

        List<IItem> items = playerItems.Concat(computerItems).ToList();

        items.ForEach(item =>
        {
            if (item != null)
            {
                if (item.gameObject.name == fearAnimal.ToString()
                || item.gameObject.name == fearAnimal.ToString() + "(Clone)")
                {
                    isFirstAnimalInList = true;
                }
                if (item.gameObject.name == selfAnimal.ToString()
                || item.gameObject.name == selfAnimal.ToString() + "(Clone)")
                {
                    isSecondAnimal = true;
                }
            }
        });

        return isFirstAnimalInList && isSecondAnimal;
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
    Computer,
    Unselected
}

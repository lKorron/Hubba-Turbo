using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HingeJoint2D))]

public class WeightComparing : MonoBehaviour
{
    private HingeJoint2D hingeJoint2d; // Use for SetBalance() method
    private UnityEvent playerWin;

    // Arrays for weight

    [SerializeField] private int _playerWeight;
    [SerializeField] private int _computerWeight;

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
            print(IsAnimalsOnBoard(Animal.Mouse, Animal.Elephant));
        }
    }

    private void OnDisable()
    {
        playerWin.RemoveAllListeners();
    }

    // Add weight to chosen array
    public void AddWeight(Item item, Side side)
    {
        int itemWeight = item.Weight;
        if (side == Side.Player)
        {
            _playerWeight += itemWeight;
        }
        else _computerWeight += itemWeight;
    }

    // Take away weight from list
    public void TakeAwayWeight(Item item, Side side)
    {
        int itemWeight = item.Weight;
        if (side == Side.Player)
        {
            _playerWeight += itemWeight;
        }
        else _computerWeight += itemWeight;
    }

    public void Compare()
    {
        if (_playerWeight == _computerWeight && _playerWeight > 0 && _computerWeight > 0)
        {
            SetBalance();
            playerWin.Invoke();
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

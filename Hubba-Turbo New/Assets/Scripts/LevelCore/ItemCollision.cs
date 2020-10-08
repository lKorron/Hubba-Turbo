using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemCollision : MonoBehaviour
{
    [SerializeField] private bool IsComputerActive = true; // Field determines will computer get turn or not
    [SerializeField] public UnityEvent OnCollision; // Event for other actions
    private WeightComparing weightComparing;
    private ObjectInstantiate objectInstantiate;
    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        weightComparing = FindObjectOfType<WeightComparing>();
        objectInstantiate = FindObjectOfType<ObjectInstantiate>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Side side = GetCollisionSide(_collider, collision);

        if (side == Side.Player)
        {

        }
        if (side == Side.Computer)
        {

        }
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
        // Other actions
        OnCollision.Invoke();
    }
    // Setting computer activity from outside
    public void SetComputerActive(bool isActive)
    {
        IsComputerActive = isActive;
    }

    // Adding item (collision) to instance array
    private void SetItem(Collision2D collision, Side side)
    {
        collision.gameObject.tag = "Untagged";

        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null && item.IsCollided == false)
        {
            print(GetCollisionSide(_collider, collision));
            item.IsCollided = true;

            weightComparing.AddItem(item, side);

        }
        else throw new System.NullReferenceException("Item equals to null");
    }

    private Side GetCollisionSide(Collider2D platformCollider, Collision2D collision)
    {
        Vector3 center = platformCollider.bounds.center;
        Vector3 contactPoint = collision.contacts[0].point;

        bool isRight = contactPoint.x > center.x;
        bool isLeft = contactPoint.x < center.x;

        if (isRight) return Side.Computer;
        if (isLeft) return Side.Player;

        else
        {
            return Side.Player;
            throw new System.Exception("Method can't correctly dermine side");
        }

    }


}

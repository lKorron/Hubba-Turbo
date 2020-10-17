using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ItemCollision : MonoBehaviour
{
    [SerializeField] private bool IsComputerActive = true; // Field determines will computer get turn or not
    [SerializeField] public UnityEvent OnCollision; // Event for other actions
    private WeightComparing weightComparing;
    private ObjectInstantiate objectInstantiate;
    private Camera _camera;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        weightComparing = FindObjectOfType<WeightComparing>();
        objectInstantiate = FindObjectOfType<ObjectInstantiate>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ItemCollision>())
        {
         
            Side side = GetCollisionSide(collision);

            SetItem(collision, side);

            // Other actions
            OnCollision.Invoke();
        }
    }
    // Setting computer activity from outside
    public void SetComputerActive(bool isActive)
    {
        IsComputerActive = isActive;
    }

    // Adding item (collision) to instance array
    private void SetItem(Collision2D collision, Side side)
    {
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null && item.IsCollided == false)
        {
            item.IsCollided = true;

            weightComparing.AddItem(item, side);
            if (side == Side.Player)
            {
                objectInstantiate.ComputerInstantiate();
            }
            if (objectInstantiate.IsComputerEndInstantiate)
            {
                weightComparing.Compare();
            }
            

        }
        ItemCollision itemCollision = collision.gameObject.GetComponent<ItemCollision>();
        if (itemCollision == null) throw new System.NullReferenceException("Item equals to null");
    }

    private Side GetCollisionSide(Collision2D collision)
    {
        Vector3 center = _camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0));
        Vector3 contactPoint = collision.contacts[0].point;

        bool isRight = contactPoint.x > center.x;
        bool isLeft = contactPoint.x < center.x;

        if (isRight) return Side.Computer;
        if (isLeft) return Side.Player;
        throw new System.Exception("Method can't correctly dermine side");

    }


}

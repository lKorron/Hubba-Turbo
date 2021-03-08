using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ItemCollision : MonoBehaviour
{
    [SerializeField] public UnityEvent OnCollision; // Event for other actions
    private WeightComparing _weightComparing;
    private ObjectInstantiate _objectInstantiate;
    private Camera _camera;
    private Side _side;

    public Side Side => _side;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _weightComparing = FindObjectOfType<WeightComparing>();
        _objectInstantiate = FindObjectOfType<ObjectInstantiate>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ItemCollision>())
        {
         
            _side = GetCollisionSide(collision);
            SetItem(collision, _side);

            // Other actions
            OnCollision.Invoke();
        }
    }

    // Adding item (collision) to instance array
    private void SetItem(Collision2D collision, Side side)
    {
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null && item.IsCollided == false)
        {
            item.IsCollided = true;

            _weightComparing.AddItem(item, side);
            _objectInstantiate.CheckComputerEndInstantiate();
            if (side == Side.Player && item.IsStartItem == false)
            {
                _objectInstantiate.ComputerInstantiate();
            }
            
            if (_objectInstantiate.IsComputerEndInstantiate)
            {
                _weightComparing.Compare();
            }
        }
        ItemCollision itemCollision = collision.gameObject.GetComponent<ItemCollision>();
        if (itemCollision == null) throw new System.NullReferenceException("Item equals to null");
    }

    public Side GetCollisionSide(Collision2D collision)
    {
        Vector3 center = _camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0));
        Vector3 contactPoint = collision.contacts[0].point;

        bool isRight = contactPoint.x > center.x;
        bool isLeft = contactPoint.x < center.x;

        if (isRight) return Side.Computer;
        if (isLeft) return Side.Player;
        throw new System.Exception("Method can't correctly dermine side");
    }

    public Side GetCollisionSide(Collider2D collision)
    {
        Vector3 center = _camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0));
        Vector3 contactPoint = collision.ClosestPoint(transform.position);

        bool isRight = contactPoint.x > center.x;
        bool isLeft = contactPoint.x < center.x;

        if (isRight) return Side.Computer;
        if (isLeft) return Side.Player;
        throw new System.Exception("Method can't correctly dermine side");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private ItemCollision _itemCollision;
    private WeightComparing _weightComparing;
    public bool IsWasCollision { get; private set; } = false;

    // destroy falling objects
    private void Start()
    {

        _weightComparing = FindObjectOfType<WeightComparing>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();

        _itemCollision = collision.gameObject.GetComponent<ItemCollision>();
        Side side = _itemCollision.GetCollisionSide(collision);
        
        _weightComparing.RemoveItem(item, side);
        Destroy(collision.gameObject);
        IsWasCollision = true;

    }
}

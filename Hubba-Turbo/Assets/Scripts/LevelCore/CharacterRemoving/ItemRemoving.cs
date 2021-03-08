using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemoving : MonoBehaviour
{
    private ItemCollision _itemCollision;
    private WeightComparing _weightComparing;

    public static ItemRemoving Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _weightComparing = FindObjectOfType<WeightComparing>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Remove(collision);
    }

    public void Remove(Collider2D collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null && item.IsRemoved == false && item.IsCollided == true)
        {
            _itemCollision = collision.gameObject.GetComponent<ItemCollision>();
            Side side = _itemCollision.GetCollisionSide(collision);
            _weightComparing.RemoveItem(item, side);
            item.IsRemoved = true;
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroying : MonoBehaviour
{
    private ItemRemoving _itemRemoving;

    private void Start()
    {
        _itemRemoving = ItemRemoving.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IItem>() != null)
        {
            _itemRemoving.Remove(collision);
            Destroy(collision.gameObject);
        }
    }
}

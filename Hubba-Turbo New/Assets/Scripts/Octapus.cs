using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octapus : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D lowFrictionMaterial;
    [SerializeField] private Sprite slipperyPlatformSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            SetPlatformSlippery(collision);
        }
    }

    private void SetPlatformSlippery(Collision2D collision)
    {
        // Change friction
        BoxCollider2D collisionBoxCollider = collision.gameObject.GetComponent<BoxCollider2D>();
        collisionBoxCollider.sharedMaterial = lowFrictionMaterial;

        // Change sprite
        SpriteRenderer collisionSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        collisionSpriteRenderer.sprite = slipperyPlatformSprite;
    }
}

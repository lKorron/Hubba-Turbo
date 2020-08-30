using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octapus : MonoBehaviour
{
    private PhysicsMaterial2D lowFrictionMaterial;
    private Sprite slipperyPlatformSprite;

    private bool isPlatformSlippery = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && isPlatformSlippery == false)
        {
            SetPlatformSlippery(collision);
        }
    }

    private void SetPlatformSlippery(Collision2D collision)
    {
        print("Start method");
        isPlatformSlippery = true;

        lowFrictionMaterial = Resources.Load<PhysicsMaterial2D>("Materials/LowFriction");
        slipperyPlatformSprite = Resources.Load<Sprite>("Sprites/Platforms/PlatformSlippery");

        // Change friction
        BoxCollider2D collisionBoxCollider = collision.gameObject.GetComponent<BoxCollider2D>();
        collisionBoxCollider.sharedMaterial = lowFrictionMaterial;

        // Change sprite
        SpriteRenderer collisionSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        collisionSpriteRenderer.sprite = slipperyPlatformSprite;
    }
}

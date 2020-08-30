using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    private PhysicsMaterial2D lowFrictionMaterial;
    private Sprite slipperyPlatformSprite;

    public bool IsPlatformSlippery { get; private set; }

    private void Start()
    {
        lowFrictionMaterial = Resources.Load<PhysicsMaterial2D>("Materials/LowFriction");
        slipperyPlatformSprite = Resources.Load<Sprite>("Sprites/Platforms/PlatformSlippery");
    }

    public void SetPlatformSlippery()
    {
        IsPlatformSlippery = true;

        // Change friction
        BoxCollider2D collisionBoxCollider = GetComponent<BoxCollider2D>();
        collisionBoxCollider.sharedMaterial = lowFrictionMaterial;

        // Change sprite
        SpriteRenderer collisionSpriteRenderer = GetComponent<SpriteRenderer>();
        collisionSpriteRenderer.sprite = slipperyPlatformSprite;
    }




}

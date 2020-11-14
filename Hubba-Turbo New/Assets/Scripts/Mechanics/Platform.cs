using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D _lowFrictionMaterial;
    [SerializeField] private Sprite _slipperyPlatformSprite;

    public bool IsPlatformSlippery { get; private set; }
    public static Platform Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetPlatformSlippery()
    {
        IsPlatformSlippery = true;

        // Change friction
        BoxCollider2D collisionBoxCollider = GetComponent<BoxCollider2D>();
        collisionBoxCollider.sharedMaterial = _lowFrictionMaterial;

        // Change sprite
        SpriteRenderer collisionSpriteRenderer = GetComponent<SpriteRenderer>();
        collisionSpriteRenderer.sprite = _slipperyPlatformSprite;
    }




}

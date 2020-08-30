using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octapus : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D lowFrictionMaterial;
    private SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Rigidbody2D collisionRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            //collisionRigidBody.sharedMaterial = lowFrictionMaterial;
        }
    }

    private void SetPlatformSlippery()
    {

    }
}

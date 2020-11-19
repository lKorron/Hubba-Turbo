using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _explodeDelay;

    private float _radius = 10.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Item>())
            Explode(_explodeDelay);
    }

    private void Explode(int delay)
    {
        Vector2 explosionPoint = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPoint, _radius);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.GetComponent<Item>())
            {
                var rigidBody = collider.GetComponent<Rigidbody2D>();


                if (rigidBody != null)
                    rigidBody.AddExplosionForce(10f, explosionPoint, _radius);
            }

            Destroy(gameObject);
        }
    }
}

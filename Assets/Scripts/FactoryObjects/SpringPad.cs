using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintPad : FactoryObject
{
    public float bounceForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovableObject")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 bounceDirection = Vector2.up;
                rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
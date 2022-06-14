using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnaSideBricksRb : Bricks
{
    private Rigidbody2D rbb;
    // Start is called before the first frame update
    void Start()
    {
        rbb = GetComponent<Rigidbody2D>();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        float coll = collision.relativeVelocity.magnitude;
        if (collision.gameObject.CompareTag("projectile"))
        {
            if (coll >= 3)
            {
                rbb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        if (collision.gameObject.CompareTag("Bricks"))
        {
            if (coll >= 3)
            {
                rbb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float dir;

    private Rigidbody2D rb;

    int bounces;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.right * speed * dir, ForceMode2D.Force);

        bounces = 0;

        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Core.CoreManager.current.health.healthSystem.Damage();
            Destroy(gameObject);
        }

        if (bounces == 1) Destroy(gameObject);
        else bounces++;
    }
}

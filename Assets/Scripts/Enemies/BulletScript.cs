using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public int facingDirection;
    public float lifeTime;

    private Rigidbody2D rb;

    public int maxBounces;

    int bounces;

    float randomRot;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Bullet");

        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.right * speed * facingDirection, ForceMode2D.Force);

        bounces = 0;

        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Damage");
            Core.CoreManager.current.health.healthSystem.Damage();
            Core.CoreManager.KnockbackPlayer(facingDirection);
            Destroy(gameObject);
        }

        if (bounces > maxBounces)
        {
            bounces = 0;
            Destroy(gameObject);
        }
        else bounces++;
    }
}

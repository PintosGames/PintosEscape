using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float speed = 10f;

    public float wallCheckDistance = 3;

    public int facingDirection = 1;

    public Transform groundCheck;
    public float groundCheckRadius;

    public LayerMask whatIsGround;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (CheckIfTouchingWall() || (CheckIfNearLedge() && CheckIfGrounded())) Flip();
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(transform.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);
    }

    public bool CheckIfNearLedge()
    {
        return !Physics2D.Raycast(new Vector2(transform.position.x + (wallCheckDistance * facingDirection), transform.position.y), Vector2.down * 1, whatIsGround);
    }

    public void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        if (CheckIfGrounded())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
        else
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

        if (CheckIfTouchingWall())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + (wallCheckDistance * facingDirection), transform.position.y));
        }
        else
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + (wallCheckDistance * facingDirection), transform.position.y));
        }

        if (CheckIfNearLedge())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x + (wallCheckDistance * facingDirection), transform.position.y), new Vector2(transform.position.x + (wallCheckDistance * facingDirection), transform.position.y - 1));
        }
        else
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(new Vector2(transform.position.x + (wallCheckDistance * facingDirection), transform.position.y), new Vector2(transform.position.x + (wallCheckDistance * facingDirection), transform.position.y - 1));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") Core.CoreManager.current.health.healthSystem.Damage();

        var player = Core.CoreManager.current.player.GetComponent<Player>();

        if (collision.gameObject.GetComponent<Player>().FacingDirection != facingDirection) collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-player.playerData.knockbackPower, player.playerData.knockbackPower));
        if (collision.gameObject.GetComponent<Player>().FacingDirection == facingDirection) collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.playerData.knockbackPower, player.playerData.knockbackPower));

        Flip();
    }
}

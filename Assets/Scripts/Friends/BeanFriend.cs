using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class BeanFriend : DialogueTrigger
{
    public float playerCheckDistance;
    public LayerMask whatIsPlayer;

    public int facingDirection = -1;

    public new AudioManager audio;

    public bool lastBean;

    private void Start()
    {
        
    }

    void Update()
    {
        if ((CheckIfInFront() || CheckIfInBack()) && CoreManager.current.player.InputHandler.InteractInput)
        {
            if (CheckIfInBack()) Flip();

            if (!CoreManager.current.dialogue.dialogueOpen)
            {
                FindObjectOfType<AudioManager>().Play("Friend");
                TriggerDialogue();
            }
            else
            {
                CoreManager.current.dialogue.DisplayNextSentence(dialogue);
            }

            CoreManager.current.player.InputHandler.InteractInput = false;
        }
    }

    public bool CheckIfInFront()
    {
        return Physics2D.Raycast(gameObject.transform.position, Vector2.right * facingDirection, playerCheckDistance, whatIsPlayer);
    }

    public bool CheckIfInBack()
    {
        return Physics2D.Raycast(gameObject.transform.position, Vector2.right * -facingDirection, playerCheckDistance, whatIsPlayer);
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        if (CheckIfInFront())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + (playerCheckDistance * facingDirection), transform.position.y, transform.position.z));
        }
        else
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + (playerCheckDistance * facingDirection), transform.position.y, transform.position.z));
        }

        if (CheckIfInBack())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + (playerCheckDistance * -facingDirection), transform.position.y, transform.position.z));
        }
        else
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + (playerCheckDistance * -facingDirection), transform.position.y, transform.position.z));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (lastBean) Core.SceneManager.LoadScene(6);
        }
    }
}

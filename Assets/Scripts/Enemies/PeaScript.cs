using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaScript : MonoBehaviour
{
    public bool autoShoot;

    public GameObject bullet;
    public Transform nozzle;

    public Animator animator;

    float timer = 0;

    public bool facingRight;
    public bool Attack { get; private set; }

    private void Start()
    {
        if (transform.rotation.y == 0) facingRight = true;
        else if (transform.rotation.y == 180) facingRight = false;

        if (autoShoot) Attack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") Attack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !autoShoot) Attack = false;
    }

    private void Update()
    {
        if (Attack) animator.SetBool("attack", true);
        else animator.SetBool("attack", false);
    }

    void Shoot()
    {
        timer = 0;

        GameObject curBul = Instantiate(bullet, nozzle.position, Quaternion.Euler(0, 0, 0), this.transform);

        if (facingRight) curBul.GetComponent<BulletScript>().facingDirection = 1;
        else curBul.GetComponent<BulletScript>().facingDirection = -1;
    }

    public void AttackFinished()
    {
        if (!autoShoot) Attack = false;
    }
}

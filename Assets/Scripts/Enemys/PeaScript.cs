using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaScript : MonoBehaviour
{
    public GameObject bullet;

    public Transform nozzle;

    float timer = 0;

    private void Update()
    {
        if (timer > 1) Shoot();

        timer += 1f * Time.deltaTime;
    }

    void Shoot()
    {
        timer = 0;

        GameObject curBul = Instantiate(bullet, nozzle.position, Quaternion.Euler(0, 0, 0), this.transform);

        if (transform.localEulerAngles.y == 0) curBul.GetComponent<BulletScript>().dir = 1;
        else curBul.GetComponent<BulletScript>().dir = -1;
    }
}

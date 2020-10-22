using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody2D projectile;

    //public float bulletSpeed;

    public float fireDelay;
    private float cooldownTimer = 0;

    // Update is called once per frame
    void Update()
    {

        cooldownTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0)
        {
            Rigidbody2D instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;

            /*instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));*/
          

            cooldownTimer = fireDelay;

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody2D projectile;
    public Transform spawnPoint;

    public float fireDelay;
    private float cooldownTimer = 0;

    // Update is called once per frame
    void Update()
    {

        cooldownTimer -= Time.deltaTime;


        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0)
        {
            Shoot();
        }
            

    }
    void Shoot() 
    {
        Rigidbody2D bullet = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation) as Rigidbody2D;

        cooldownTimer = fireDelay;

    }
}

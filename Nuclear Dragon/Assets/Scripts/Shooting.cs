using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;

    public float fireDelay;
    public float cooldownTimer;

    // Update is called once per frame
    
    public void Shoot(bool Player) 
    {
        GameObject bullet = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

        cooldownTimer = fireDelay;

        if(Player)
        {
            bullet.layer = 8;
        }
    }
}

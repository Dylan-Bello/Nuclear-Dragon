using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;

    public float fireDelay;
    public float cooldownTimer;
    private int projectileIndex = 0;

    public GameObject[] ProjectileType = new GameObject[3];

    public void Shoot(bool Player) 
    {
        GameObject bullet = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

        cooldownTimer = fireDelay;

        if(Player)
        {
            bullet.layer = 11;
        }
    }

    public void ChangeWeapon()
    {
        if(projectileIndex <= ProjectileType.Length)
        {
            projectileIndex++;
            this.projectile = ProjectileType[projectileIndex];


        }
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 0.1f; 
    public int damageToGive;


    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0* Time.deltaTime, bulletSpeed);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damageToGive);
    }
}

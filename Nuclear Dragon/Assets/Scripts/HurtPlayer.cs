﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damageToGive);
        }
        if(other.gameObject.name == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damageToGive);
        }
    }
}

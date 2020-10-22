using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireDelay = 0.5f;
    private float cooldownTimer = 0;
    private Rigidbody2D rb;
    public float bulletSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0)
        {
            Vector2 force = transform.up * bulletSpeed;

            rb.AddForce(force);
            Debug.Log("Fire!");
            cooldownTimer = fireDelay;
        }


    }

}

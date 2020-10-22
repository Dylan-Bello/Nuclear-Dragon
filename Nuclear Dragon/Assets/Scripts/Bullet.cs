using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed;
    public int damageToGive;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 velocity = new Vector2(bulletSpeed * Time.deltaTime, 0);
        pos = transform.rotation * velocity;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damageToGive);
    }
}

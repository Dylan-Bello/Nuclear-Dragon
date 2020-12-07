using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 3f; 
    public int damageToTake;


    void Awake()
    {
       Destroy(this.gameObject, 3f);

    }
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0 * Time.deltaTime, bulletSpeed);
        pos += transform.rotation * velocity;
        transform.position = pos;

        //Debug.Log("Working");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damageToTake);

            

            Destroy(this.gameObject);

            //Debug.Log("Bullet Hit!");
        }
        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damageToTake);

            

            Destroy(this.gameObject);

            //Debug.Log("Bullet Hit!");
        }
        //Debug.Log("Collision Detected");
    }

}

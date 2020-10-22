using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DylanShooting : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float speed;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            Rigidbody2D instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation) as Rigidbody2D;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

        }
  
    }
   
}

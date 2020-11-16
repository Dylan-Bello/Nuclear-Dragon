using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Shooting shooting;
    

    // Start is called before the first frame update
    void Awake()
    {
        shooting = this.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {

        shooting.cooldownTimer -= Time.deltaTime;


        if (Input.GetKey(KeyCode.Space) && shooting.cooldownTimer <= 0)
        {
            shooting.Shoot(true);
        }


    }
}

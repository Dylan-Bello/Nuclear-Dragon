using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Shooting shooting;
    private MainMenu pause;
    

    // Start is called before the first frame update
    void Awake()
    {
        shooting = this.GetComponent<Shooting>();
        pause = this.GetComponent<MainMenu>();
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

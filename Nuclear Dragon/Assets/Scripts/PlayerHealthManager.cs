using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    private int playerStartingHealth = 50;
    public int playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerStartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth <= 0)
        {
            Destroy(this.gameObject, 1f);
        }
    }

    public void TakeDamage (int damageToTake)
    {
        playerCurrentHealth -= damageToTake;
    }

   
}

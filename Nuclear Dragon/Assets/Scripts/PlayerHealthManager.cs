using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{

    public int playerStartingHealth = 50;
    public int playerCurrentHealth;

    public Healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerStartingHealth;

        healthBar.SetMaxHealth(playerStartingHealth);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void TakeDamage (int damageToTake)
    {
        playerCurrentHealth -= damageToTake;

        healthBar.SetHealth(playerCurrentHealth);
    }

    

   
}

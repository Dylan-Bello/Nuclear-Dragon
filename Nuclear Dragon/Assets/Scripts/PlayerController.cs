using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int score;

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

        //quit game
        if (Input.GetKey(KeyCode.Escape) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

    
}

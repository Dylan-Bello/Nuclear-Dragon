using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float xp = 0;
    public float xpForNextLevel = 10;
    public int level = 1;


    private Shooting shooting;
    private PlayerHealthManager health;


    private void Start()
    {
        SetXpForNextLevel();
        
    }


    void Awake()
    {
        shooting = this.GetComponent<Shooting>();
        health = this.GetComponent<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

        shooting.cooldownTimer -= Time.deltaTime;

        //Shoot
        if (Input.GetKey(KeyCode.Space) && shooting.cooldownTimer <= 0)
        {
            shooting.Shoot(true);
        }

        //Quit game
        if (Input.GetKey(KeyCode.Escape) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        //Level up
        if (xp >= xpForNextLevel)
        {
            LevelUp();
            shooting.ChangeWeapon();
            health.RegenHealthFull();
        }


    }

    void SetXpForNextLevel()
    {
        xpForNextLevel = (10f + (level * level * 1f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }

    void LevelUp()
    {
        xp = 0f;
        level++;

        Debug.Log("level" + level);
        SetXpForNextLevel();

    }

    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + " XP, Current Xp = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);
    }




}

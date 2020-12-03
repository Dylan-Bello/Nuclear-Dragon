using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float stopDistance;

    public float fireRange;
    public float fireDelay;

    public int xpValue = 1;
    //public GameObject Projectile;

    //How much time between bursts
    public float burstDelay;
    //How many bullets per burst
    public float bulletsPerBurst;

    private float cooldownTimer;
    private float burstCount;
    private float burstCoolDownTimer;

    //Gavin's edit
    public int enemyStartingHealth = 20;
    public int enemyCurrentHealth;
    public int scoreValue = 10;

    public Transform target;
    private Rigidbody rb;




// Start is called before the first frame update
void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        //Gavin's edit
        enemyCurrentHealth = enemyStartingHealth;

    }

    // Update is called once per frame
    void Update()
    {

        //transform.LookAt(Vector3.zero);
        cooldownTimer -= Time.deltaTime;
        burstCoolDownTimer -= Time.deltaTime;

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle);

        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            Chase();
        }

        if (Vector2.Distance(transform.position, target.position) < fireRange && cooldownTimer <= 0 && burstCoolDownTimer <= 0)
        {
            this.gameObject.GetComponent<Shooting>().Shoot(false);
            cooldownTimer = fireDelay;

            //A second timer for spacing out bursts of projectiles
            burstCount++;
            if (burstCount >= bulletsPerBurst)
            {
                burstCount = 0;
                burstCoolDownTimer = burstDelay;
            }

        }

        UpdateRotation(rotation);

         
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void UpdateRotation(Vector3 angle)
    {
        Quaternion rotation = Quaternion.Euler(angle);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }

    //Gavin's edit
    void FixedUpdate()
    {
        if(enemyCurrentHealth <= 0)
        {
            ScoreManager.score += scoreValue;
            Destroy(this.gameObject);
            target.GetComponent<PlayerController>().GainXP(xpValue);

        }
    }

    public void TakeDamage (int damageToTake)
    {
        enemyCurrentHealth -= damageToTake;
    }



}

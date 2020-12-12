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
    public int healthToGive;
    //public GameObject Projectile;

    //How much time between bursts
    public float burstDelay;
    //How many bullets per burst
    public float bulletsPerBurst;

    private float cooldownTimer;
    private float burstCount = 0;
    private float burstCoolDownTimer;

    //Gavin's edit
    public int enemyStartingHealth = 20;
    public int enemyCurrentHealth;
    public int scoreValue = 10;

    public Transform shootTarget;
    public Transform[] wayPoints;
    private int wayPointsIndex;
    private Rigidbody rb;

    public bool isPlayerChaser;
    public bool isPatroller;
    private bool waypointsCreated = false;
    public GameObject waypointObject;

    void Start()
    {
        shootTarget = GameObject.FindGameObjectWithTag("Player").transform;
        wayPointsIndex = 0;

        if (isPlayerChaser == true)
        {
            wayPoints[0] = GameObject.FindGameObjectWithTag("Player").transform;
        }



        //Gavin's edit
        enemyCurrentHealth = enemyStartingHealth;

    }

    // Update is called once per frame
    void Update()
    {

        //transform.LookAt(Vector3.zero);
        cooldownTimer -= Time.deltaTime;
        burstCoolDownTimer -= Time.deltaTime;

        Vector3 direction = shootTarget.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle);

        if (isPatroller == true && waypointsCreated == false)
        {

            GameObject waypoint1 = Instantiate(waypointObject, this.transform.position, this.transform.rotation);
            float newX = (this.transform.position.x - 75f);
            float newY = (this.transform.position.y);
            waypoint1.transform.position = new Vector3(newX, newY);

            GameObject waypoint2 = Instantiate(waypointObject, this.transform.position, this.transform.rotation);
            newX = (this.transform.position.x);
            newY = (this.transform.position.y - 75f);
            waypoint2.transform.position = new Vector3(newX, newY);

            GameObject waypoint3 = Instantiate(waypointObject, this.transform.position, this.transform.rotation);
            newX = (this.transform.position.x + 75f);
            newY = (this.transform.position.y);
            waypoint3.transform.position = new Vector3(newX, newY);

            GameObject waypoint4 = Instantiate(waypointObject, this.transform.position, this.transform.rotation);
            newX = (this.transform.position.x);
            newY = (this.transform.position.y + 75f);
            waypoint4.transform.position = new Vector3(newX, newY);

            wayPoints[0] = waypoint1.transform;
            wayPoints[1] = waypoint2.transform;
            wayPoints[2] = waypoint3.transform;
            wayPoints[3] = waypoint4.transform;

            waypointsCreated = true;
        }

        if (Vector2.Distance(transform.position, wayPoints[wayPointsIndex].position) > stopDistance)
        {
            Chase();
        }



        else //when reaching destination, select and move to the next destination,
        {
            wayPointsIndex++;
            if (wayPointsIndex == wayPoints.Length)
            {
                //and then back to the start.
                wayPointsIndex = 0;
            }
        }

        if (Vector2.Distance(transform.position, shootTarget.position) < fireRange && cooldownTimer <= 0 && burstCoolDownTimer <= 0)
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
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPointsIndex].position, moveSpeed * Time.deltaTime);
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
            shootTarget.GetComponent<PlayerController>().GainXP(xpValue);
            shootTarget.GetComponent<PlayerHealthManager>().RegenHealth(healthToGive);

        }
    }

    public void TakeDamage (int damageToTake)
    {
        enemyCurrentHealth -= damageToTake;
    }



}

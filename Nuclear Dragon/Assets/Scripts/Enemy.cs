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

    private float cooldownTimer;

    public Transform target;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Vector3.zero);
        cooldownTimer -= Time.deltaTime;

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle);

        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            Chase();
        }

        if (Vector2.Distance(transform.position, target.position) < fireRange && cooldownTimer <= 0)
        {
            this.gameObject.GetComponent<Shooting>().Shoot();
            cooldownTimer = fireDelay;
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

}

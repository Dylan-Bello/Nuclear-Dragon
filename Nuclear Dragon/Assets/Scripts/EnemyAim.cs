using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    public float rotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Find direction from enemy to player in Radians
        Vector3 direction = player.position - transform.position;
        //convert to Degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle);

        UpdateRotation(rotation);
        //rb.rotation = angle;
        //transform.LookAt(player);
    }

    void UpdateRotation(Vector3 angle)
    {
        Quaternion rotation = Quaternion.Euler(angle);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}

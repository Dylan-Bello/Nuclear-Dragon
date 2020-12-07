using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    public float maxVelocity;

    public float turnSpeed;

    private Rigidbody2D rb;

    GameObject player;

    public bool thrust = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
       
        Thrust(yAxis);
        
        Rotate(transform, xAxis * -turnSpeed);

        Vector3 endPos = player.transform.position;

        transform.position = new Vector3(
            Mathf.Clamp(endPos.x, -760f, 1000f),
            Mathf.Clamp(endPos.y, -80f, 230f), transform.position.z);

       


    }

    void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }
    void Thrust(float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);

        
    }
    void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    public void CheckThrust()
    {
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            thrust = true;
            Debug.Log("Thrusting");
        }
    }
}

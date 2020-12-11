using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpawner : MonoBehaviour
{
    public GameObject enemyType;
    private GameObject spawnLocation;

    public Transform spawnPoint;
    public int count;
    public float rate;
    private float timer;

    private GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        timer = rate;
        spawnLocation = this.gameObject;

        enemy = Instantiate(enemyType, spawnPoint.position, spawnPoint.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = rate;
            enemy = Instantiate(enemyType, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

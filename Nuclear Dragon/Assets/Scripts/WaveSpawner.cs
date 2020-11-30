using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float spawnDelay = 5;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {

        }
    }
}

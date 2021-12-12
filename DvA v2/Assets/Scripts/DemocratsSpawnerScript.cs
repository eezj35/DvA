using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemocratsSpawnerScript : MonoBehaviour
{
    public GameObject democrat;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 6f;
    float nextSpawn = 0.0f;
    private float maxY = 4.0f;
    private float minY = -4.40f;
    private int counter = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(minY, maxY);
            whereToSpawn = new Vector2(transform.position.x, randY);
            Instantiate(democrat, whereToSpawn, Quaternion.identity);
            counter++;
            if (counter % 10 == 0 && spawnRate >= 1f)
            {
                spawnRate -= 0.1f;
            }
        }
    }
}

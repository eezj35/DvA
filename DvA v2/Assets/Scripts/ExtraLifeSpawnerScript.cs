using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeSpawnerScript : MonoBehaviour
{
    public GameObject extraLife;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 15f;
    float nextSpawn = 15f;
    private float maxX = 7.15f;
    private float minX = -7.05f;
    private float maxY = 2.5f;
    private float minY = -3.95f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(minX, maxX);
            randY = Random.Range(minY, maxY);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(extraLife, whereToSpawn, Quaternion.identity);
        }
    }
}

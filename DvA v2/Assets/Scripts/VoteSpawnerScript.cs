using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteSpawnerScript : MonoBehaviour
{
    public GameObject vote;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 4f;
    float nextSpawn = 0.0f;
    private float maxX = 7.15f;
    private float minX = -7.05f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(minX, maxX);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(vote, whereToSpawn, Quaternion.identity);
        }
    }
}

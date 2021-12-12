using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip votesCollect;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = votesCollect;
        Physics2D.IgnoreLayerCollision(12, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(11, 10);
        Physics2D.IgnoreLayerCollision(12, 10);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bottom")
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.1f);
            ScoreScript.scoreVal += 1;
        }
    }
}

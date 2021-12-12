using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeScript : MonoBehaviour
{
    public AudioClip healthCollect;
    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = healthCollect;
        Physics2D.IgnoreLayerCollision(9, 13);
        Physics2D.IgnoreLayerCollision(8, 13);
        Physics2D.IgnoreLayerCollision(10, 13);
        Physics2D.IgnoreLayerCollision(11, 13);
        Physics2D.IgnoreLayerCollision(12, 13); 
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(9, 13);
        Physics2D.IgnoreLayerCollision(8, 13);
        Physics2D.IgnoreLayerCollision(10, 13);
        Physics2D.IgnoreLayerCollision(11, 13);
        Physics2D.IgnoreLayerCollision(12, 13);
        if (isHit)
        {
            Destroy(gameObject, 0.05f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<AudioSource>().Play();
        isHit = true;
        GameControlScript.health += 1;
    }
}

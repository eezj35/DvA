using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyScript : MonoBehaviour
{
    public AudioClip explosion;
    private Animator enemyAnimation;
    private bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimation = GetComponent<Animator>();
        enemyAnimation.enabled = true;
        GetComponent<AudioSource>().clip = explosion;
        Physics2D.IgnoreLayerCollision(9, 8);
        Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(9, 11);
        Physics2D.IgnoreLayerCollision(9, 12);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(9, 8);
        Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(9, 11);
        Physics2D.IgnoreLayerCollision(9, 12);
        if (isHit)
        {
            enemyAnimation.SetBool("Contact", true);
            Destroy(gameObject, 1f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        else
        {
            isHit = true;
            GetComponent<AudioSource>().Play();
            GameControlScript.health -= 2;
        }
    }
}

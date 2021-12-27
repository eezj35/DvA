using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecrease : MonoBehaviour
{
    [SerializeField] private float damageValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damageValue);
            //gameObject.SetActive(false);
        }
    }

}


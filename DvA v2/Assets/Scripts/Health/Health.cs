using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth;
    private Animator anim;
    private bool isDead;

    private void Awake()
    {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
    }

    // givenDamage is any number from 1 to 10. value 1 means one health heart gone
    public void TakeDamage(float givenDamage)
    {
        currentHealth = Mathf.Clamp(currentHealth - givenDamage, 0, startHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!isDead)
            {
                anim.SetTrigger("die");
                GetComponent<CharController>().enabled = false;
                isDead = true;
            }
            
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    // Test function
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

}
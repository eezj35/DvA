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

    //Test function
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

}

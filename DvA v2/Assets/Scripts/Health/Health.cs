using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth;
    private Animator anim;

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
            anim.SetTrigger("die");
        }
    }

}

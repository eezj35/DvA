using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private CharController charController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        charController = GetComponent<CharController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (cooldownTimer > attackCooldown))
        {
            Shoot();
        }

        cooldownTimer += Time.deltaTime;
    }

    void Shoot()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        float localScaleX = firePoint.localScale.x;
        if (!charController.facingRight)
        {
            
            localScaleX = -localScaleX;
        }

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(localScaleX));

    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}

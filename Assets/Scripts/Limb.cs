using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public int limbHealth = 150;
    public bool canFall;
    public bool addforce;

    int health;
    bool isDead;

    Health baseHealth;
    Rigidbody rb;

    private void Start()
    {
        health = limbHealth;
        baseHealth = transform.root.GetComponent<Health>();
        rb = GetComponent<Rigidbody>();
    }

    public void TookDamage(int damage)
    {
        health -= damage;
        baseHealth.TookDamage(damage);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Died();
        }
    }

    void Died()
    {
        baseHealth.LimbDestroyed();

        if(canFall)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;

            if (addforce)
                rb.AddForce(-transform.forward * 5, ForceMode.Impulse);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

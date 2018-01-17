using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public int limbHealth = 150;

    int health;
    bool isDead;

    Health baseHealth;

    private void Start()
    {
        health = limbHealth;
        baseHealth = transform.root.GetComponent<Health>();
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
    }
}

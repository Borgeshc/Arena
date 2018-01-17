using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPool = 1000;

    int health;

    bool isDead;

    private void Start()
    {
        health = healthPool;
    }

    public void TookDamage(int damage)
    {
        health -= damage;

        if(health <= 0 && !isDead)
        {
            isDead = true;
            Died();
        }
    }

    void Died()
    {
        
    }

    public void LimbDestroyed()
    {
        TookDamage(100);
    }
}




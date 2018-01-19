using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public int healthPool = 1000;

    int health;

    bool isDead;
    Animator anim;
    NavMeshAgent agent;

    private void Start()
    {
        health = healthPool;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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
        anim.SetBool("IsDead", true);
        agent.isStopped = true;
    }

    public void LimbDestroyed()
    {
        TookDamage(100);
    }
}




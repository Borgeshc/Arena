using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public float followDistance = 15f;

    [Space, Header("Phase One")]
    public float phaseOneFrequency = 10f;
    public float phaseOneRange = 25f;
    public GameObject indicator;
    public GameObject explosion;
    public GameObject[] topCannons;
    public GameObject[] leftCannons;
    public GameObject[] rightCannons;

    GameObject player;
    NavMeshAgent agent;
    Animator anim;

    bool phaseOneActive;

    Vector3 targetPositionOne;
    Vector3 targetPositionTwo;
    Vector3 targetPositionThree;

    private void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        phaseOneActive = true;
        StartCoroutine(WaitForPhaseOne());
    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(agent.velocity == Vector3.zero)
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);

        if(distance > followDistance)
            agent.SetDestination(player.transform.position);
        else
            agent.SetDestination(transform.position);

        if(!phaseOneActive)
        {
            phaseOneActive = true;
            PhaseOne();
            StartCoroutine(WaitForPhaseOne());
        }
    }

    IEnumerator WaitForPhaseOne()
    {
        yield return new WaitForSeconds(phaseOneFrequency);
        phaseOneActive = false;
    }

    void PhaseOne()
    {
        phaseOneActive = true;
        targetPositionOne = new Vector3(Random.Range(-phaseOneRange, phaseOneRange), 0, Random.Range(-phaseOneRange, phaseOneRange));
        targetPositionTwo = new Vector3(Random.Range(-phaseOneRange, phaseOneRange), 0, Random.Range(-phaseOneRange, phaseOneRange));
        targetPositionThree = new Vector3(Random.Range(-phaseOneRange, phaseOneRange), 0, Random.Range(-phaseOneRange, phaseOneRange));

        targetPositionOne += new Vector3(10, 0, 10);
        targetPositionTwo += new Vector3(10, 0, 10);
        targetPositionThree += new Vector3(10, 0, 10);

        TriggerFire indicator1 = Instantiate(indicator, targetPositionOne, Quaternion.identity).GetComponent<TriggerFire>();
        TriggerFire indicator2 = Instantiate(indicator, targetPositionTwo, Quaternion.identity).GetComponent<TriggerFire>();
        TriggerFire indicator3 = Instantiate(indicator, targetPositionThree, Quaternion.identity).GetComponent<TriggerFire>();

        indicator1.SetTarget(this);
        indicator2.SetTarget(this);
        indicator3.SetTarget(this);
    }

    public void TriggerTopCannons()
    {
        for (int i = 0; i < topCannons.Length; i++)
        {
            topCannons[i].SetActive(true);
        }

        phaseOneActive = false;
    }

    public void TopCannonsExplosions()
    {
        Instantiate(explosion, targetPositionOne, Quaternion.identity);
        Instantiate(explosion, targetPositionTwo, Quaternion.identity);
        Instantiate(explosion, targetPositionThree, Quaternion.identity);
    }
}

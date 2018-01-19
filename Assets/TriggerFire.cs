using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFire : MonoBehaviour
{
    Boss boss;

    public void SetTarget(Boss target)
    {
        boss = target;
    }

    public void TriggerTopCannons()
    {
        boss.TriggerTopCannons();
    }

    public void TriggerTopCannonExplosions()
    {
        boss.TopCannonsExplosions();
        Destroy(gameObject);
    }
}

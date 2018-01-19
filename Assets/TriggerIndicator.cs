using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIndicator : MonoBehaviour
{
    TriggerFire triggerFire;

	void Start()
    {
        triggerFire = transform.root.GetComponent<TriggerFire>();
    }

    public void TriggerIndicatorFire()
    {
        triggerFire.TriggerTopCannons();
    }

    public void TriggerIndicatorExplosions()
    {
        triggerFire.TriggerTopCannonExplosions();
    }
}

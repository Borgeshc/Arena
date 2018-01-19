using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfter : MonoBehaviour
{
    public float disableAfter = 1f;

    private void OnEnable()
    {
        StartCoroutine(DisableObjectAfter());
    }

    IEnumerator DisableObjectAfter()
    {
        yield return new WaitForSeconds(disableAfter);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public int destroyAfter;

    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }
}

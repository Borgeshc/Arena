using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{

    public float recoilAmount;
    public float recoilSpeed;

    float recoil;
    float originalPos;

    private void Start()
    {
        originalPos = transform.localPosition.z;
    }

    public void Fire()
    {
        recoil += 0.1f;
    }

    void Update()
    {
        Recoiling();
    }

    void Recoiling()
    {
        if (recoil > 0)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition,
                new Vector3(transform.localPosition.x, transform.localPosition.y, recoilAmount), Time.deltaTime * recoilSpeed);
            recoil -= Time.deltaTime;
        }
        else
        {
            recoil = 0;
            transform.localPosition = Vector3.Lerp(transform.localPosition,
                new Vector3(transform.localPosition.x, transform.localPosition.y, originalPos), Time.deltaTime * recoilSpeed / 2);
        }
    }
}

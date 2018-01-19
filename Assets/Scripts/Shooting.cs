using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public LayerMask targetMask;
    public GameObject hitEffect;
    GameObject muzzleFlash;
    int damage;
    float attackRange;
    float fireFrequency;
    float accuracy;

    Animator anim;

    Camera mainCamera;
    float muzzleFrequency;

    bool isFiring;

    private void Start()
    {
        mainCamera = Camera.main;

        muzzleFrequency = fireFrequency * .6f;
    }

    public void Update()
    {
       if(Input.GetKey(KeyCode.Mouse0) && !isFiring)
        {
            isFiring = true;
            StartCoroutine(MuzzleFlash());
            Fire();
            anim.SetTrigger("Fire");
            StartCoroutine(FireFrequency());
        }
    }

    void Fire()
    {
        RaycastHit hit;
        Vector3 firePosition = new Vector3(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy));
        if (Physics.Raycast(mainCamera.transform.position + firePosition, mainCamera.transform.forward, out hit, attackRange, targetMask))
        {
            if(hit.transform.tag.Equals("Enemy"))
            {
                hit.transform.GetComponent<Limb>().TookDamage(damage);
            }

            Vector3 position = hit.point + (hit.normal * .1f);
            Quaternion rotation = Quaternion.LookRotation(hit.normal);

            if (hitEffect != null)
                Instantiate(hitEffect, position, rotation);
        }
    }

    IEnumerator FireFrequency()
    {
        yield return new WaitForSeconds(fireFrequency);
        isFiring = false;
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(muzzleFrequency);
        muzzleFlash.SetActive(false);
    }

    public void SetClassValues(int _damage, float _attackRange, float _fireFrequency, float _accuracy, GameObject _muzzleFlash, Animator _anim)
    {
        damage = _damage;
        attackRange = _attackRange;
        fireFrequency = _fireFrequency;
        accuracy = _accuracy;
        muzzleFlash = _muzzleFlash;
        anim = _anim;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 350f;
    public float rotationSpeed = 100f;

    float horizontal;
    float horizontal2;
    float vertical;
    float xRotationValue;

    Quaternion rotation;
    Vector3 movement;
    Rigidbody rb;
    Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        horizontal2 = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);
        movement *= speed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        rb.velocity = movement;

        if (rb.velocity == Vector3.zero)
            anim.SetBool("IsMoving", false);
        else
            anim.SetBool("IsMoving", true);

        Rotate();
	}

    void Rotate()
    {
        xRotationValue -= -horizontal2 * rotationSpeed * Time.deltaTime;
        rotation = Quaternion.Euler(0, xRotationValue, 0);
        transform.rotation = rotation;
    }

    public void SetClassValues(Animator _anim)
    {
        anim = _anim;
    }
}

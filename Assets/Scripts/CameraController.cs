using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraHolder;
    public Camera myCamera;

    public float rotationSpeed = 100f;
    public float clampValue = 90f;

    public bool hideCursor = true;

    float vertical2;

    float xRotationValue;
    float yRotationValue;
    Quaternion cameraYRotation;

    Vector3 offset;

    private void Start()
    {
        if(hideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        vertical2 = Input.GetAxis("Mouse Y");
        Look();
    }

    public void SetOffset(Vector3 newOffset)
    {
        offset = newOffset;
    }

    void Look()
    {
        yRotationValue += -vertical2 * rotationSpeed * Time.deltaTime;

        yRotationValue = ClampAngle(yRotationValue, -clampValue, clampValue);
        cameraYRotation = Quaternion.Euler(yRotationValue, 0, 0);
        cameraHolder.transform.localRotation = Quaternion.Slerp(myCamera.transform.localRotation, cameraYRotation, 1);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f)
            angle += 360.0f;
        if (angle > 360.0f)
            angle -= 360.0f;
        return Mathf.Clamp(angle, min, max);
    }
}

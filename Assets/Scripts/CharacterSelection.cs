using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public CameraController cameraController;

    public enum Class
    {
        assault,
        heavy,
    };

    public Class currentClass;

    [Space, Header("Assault Class")]
    public Animator assaultAnimator;
    public GameObject assaultClass;
    public Vector3 assaultPosition;
    public GameObject assaultReticle;
    public GameObject assaultMuzzleFlash;
    public int assaultDamage;
    public float assaultAttackRange;
    public float assaultFireFrequency;
    public float assaultAccuracy;

    [Space, Header("Heavy Class")]
    public Animator heavyAnimator;
    public GameObject heavyClass;
    public Vector3 heavyPosition;
    public GameObject heavyReticle;
    public GameObject heavyMuzzleFlash;
    public int heavyDamage;
    public float heavyAttackRange;
    public float heavyFireFrequency;
    public float heavyAccuracy;

    Shooting shooting;
    Movement movement;

    void Start ()
    {
        GameObject player = GameObject.Find("Player");
        shooting = player.GetComponent<Shooting>();
        movement = player.GetComponent<Movement>();

        switch (currentClass)
        {
            case Class.assault:
                assaultClass.SetActive(true);
                assaultReticle.SetActive(true);
                cameraController.SetOffset(assaultPosition);
                shooting.SetClassValues(assaultDamage, assaultAttackRange, assaultFireFrequency, assaultAccuracy, assaultMuzzleFlash, assaultAnimator);
                movement.SetClassValues(assaultAnimator);
                break;

            case Class.heavy:
                heavyClass.SetActive(true);
                heavyReticle.SetActive(true);
                cameraController.SetOffset(heavyPosition);
                shooting.SetClassValues(heavyDamage, heavyAttackRange, heavyFireFrequency, heavyAccuracy, heavyMuzzleFlash, heavyAnimator);
                movement.SetClassValues(heavyAnimator);
                break;
        }
    }
}

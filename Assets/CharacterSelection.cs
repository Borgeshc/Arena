using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public CameraController cameraController;

    [Space]
    public GameObject assultClass;
    public GameObject heavyClass;
    public GameObject meleeClass;

    public Vector3 assultPosition;
    public Vector3 heavyPosition;
    public Vector3 meleePosition;

    public GameObject assultReticle;
    public GameObject heavyReticle;
    public GameObject meleeReticle;

    public enum Class
    {
        assult,
        heavy,
        melee
    };

    public Class currentClass;

    void Start ()
    {
        switch (currentClass)
        {
            case Class.assult:
                assultClass.SetActive(true);
                assultReticle.SetActive(true);
                cameraController.SetOffset(assultPosition);
                break;

            case Class.heavy:
                heavyClass.SetActive(true);
                heavyReticle.SetActive(true);
                cameraController.SetOffset(heavyPosition);
                break;

            case Class.melee:
                meleeClass.SetActive(true);
                meleeReticle.SetActive(true);
                cameraController.SetOffset(meleePosition);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [Tooltip("Toggle to look at or away from player")]
    public bool lookAtOrAway;
    private int one;

    [Tooltip("Follow x axis")]
    public bool lookX = false;

    [Tooltip("Follow y axis")]
    public bool lookY = false;

    [Tooltip("Follow z axis")]
    public bool lookZ = false;

    private GameObject cameraObject = null;
    private Vector3 originalRotation = Vector3.zero;

    private void Awake()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        originalRotation = transform.eulerAngles;
    }

    private void Update()
    {
        if (lookAtOrAway)
        {
            one = -1;
        }
        else
        {
            one = 1;
        }
        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = transform.position + (one * cameraObject.transform.position);
        Vector3 newRotation = Quaternion.LookRotation(direction, transform.up).eulerAngles;

        newRotation.x = lookX ? newRotation.x : originalRotation.x;
        newRotation.y = lookY ? newRotation.y : originalRotation.y;
        newRotation.z = lookZ ? newRotation.z : originalRotation.z;

        transform.rotation = Quaternion.Euler(newRotation);
    }
}
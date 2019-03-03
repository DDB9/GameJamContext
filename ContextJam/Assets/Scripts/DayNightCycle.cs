using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float cycleSpeedModifier = 1f;

    // Update is called once per frame
    void Update()
    {
        // Rotates the sun & moon around the axis of the world with a modifyable speed.
        transform.RotateAround(Vector3.zero, Vector3.right, cycleSpeedModifier * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}

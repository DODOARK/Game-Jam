using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIntensity : MonoBehaviour
{
    public Light lightF;

    public float min;
    public float max;

    public float changeSpeed;

    private bool increase = false;

    private void FixedUpdate()
    {
        if (increase)
        {
            lightF.intensity += changeSpeed;
            if (lightF.intensity > max) increase = false;
        }
        else
        {
            lightF.intensity -= changeSpeed;
            if (lightF.intensity < min) increase = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    float rangeMultiplier =4f;
    void Start()
    {
        Light[] allLights = FindObjectsOfType<Light>();
        foreach (Light light in allLights)
        {
            if (light.type == LightType.Point)
            {
                light.range *= rangeMultiplier;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

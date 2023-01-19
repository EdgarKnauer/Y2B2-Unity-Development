using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorChange : MonoBehaviour
{
    public float gradientLevel = 0f;
    private bool button = false;


    public void Color()
    {
        button = true;
    }

    private void Update()
    {
        if (gradientLevel < 0.5f && button == true)
        {
            gradientLevel = gradientLevel + 0.005f;
            GetComponent<MeshRenderer>().material.SetFloat("FluidColor", gradientLevel);
        }
    }
}
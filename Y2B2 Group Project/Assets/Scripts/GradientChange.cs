using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientChange : MonoBehaviour
{
    [SerializeField] float liquidLevel;
    [SerializeField] GameObject flask;
    public float gradientLevel = 0f;
    private float newLiquidLevel = 0f;

    private void FixedUpdate()
    {
        if (flask.transform.rotation.eulerAngles.z > 90 && flask.transform.rotation.eulerAngles.z < 270)
        {
            if(liquidLevel > -0.11f)
            {
                liquidLevel = liquidLevel - 0.001f;
                GetComponent<MeshRenderer>().material.SetFloat("FluidLevel", liquidLevel);
            }
        }

        if (gradientLevel < 0.5f && newLiquidLevel != liquidLevel)
        {
            gradientLevel = gradientLevel + 0.0025f;
            //gradientLevel = -liquidLevel * 25 / 11;
            GetComponent<MeshRenderer>().material.SetFloat("FluidColor", gradientLevel);
            newLiquidLevel = liquidLevel;
        }
    }
}

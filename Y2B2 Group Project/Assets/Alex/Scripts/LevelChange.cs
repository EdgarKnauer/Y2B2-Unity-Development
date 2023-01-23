using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    [SerializeField] float liquidLevel;
    [SerializeField] GameObject flask;

    private void Update()
    {
        if (flask.transform.rotation.eulerAngles.z > 90 && flask.transform.rotation.eulerAngles.z < 270)
        {
            if (liquidLevel > -0.11f)
            {
                liquidLevel = liquidLevel - 0.0025f;
                //GetComponent<MeshRenderer>().material.SetFloat("FluidLevel", liquidLevel);
            }
        }
    }
}

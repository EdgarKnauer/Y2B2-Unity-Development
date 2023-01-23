using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange2 : MonoBehaviour
{
    [SerializeField] float liquidLevel2;
    [SerializeField] GameObject pouringFlask;
    public float gradientLevel = 0f;
    private bool button = false;

    private void Update()
    {
        Debug.Log("currentLiquidLevel" + liquidLevel2);
        GetComponent<MeshRenderer>().material.SetFloat("FluidLevel", liquidLevel2);

        if (pouringFlask.transform.rotation.eulerAngles.z > 90 && pouringFlask.transform.rotation.eulerAngles.z < 270)
        {
            if (liquidLevel2 < 0.11f)
            {
                liquidLevel2 = liquidLevel2 + 0.002f;
                GetComponent<MeshRenderer>().material.SetFloat("FluidLevel", liquidLevel2);
            }
            if (liquidLevel2 > 0.1f)
            {
                Color();
            }
            if (button == true)
            {
                gradientLevel = gradientLevel + 0.0035f;
                GetComponent<MeshRenderer>().material.SetFloat("FluidColor", gradientLevel);
            }
        }

    }
    private void Color()
    {
        StartCoroutine(ChangingColors());
    }
    private IEnumerator ChangingColors()
    {
        yield return new WaitForSeconds(2);
        button = true;
    }
}
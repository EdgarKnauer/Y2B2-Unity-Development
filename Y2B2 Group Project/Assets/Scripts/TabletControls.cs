using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TabletControls : MonoBehaviour
{
    //[SerializeField] private PostProcessVolume _postProcessVolume;
    [SerializeField] private GameObject tablet;
    //private Vignette _vignette;
    //private ColorAdjustments _colorAdjustments;
    private bool menuOpen = false;
    private bool blurEffect = false;

    [SerializeField] private GameObject effect1;
    [SerializeField] private GameObject effect2;
    [SerializeField] private GameObject effect3;



    private void Start()
    {
        GameObject cameraBlur = GameObject.Find("Main Camera");
        //_postProcessVolume.profile.TryGetSettings(out _vignette);
        //_postProcessVolume.profile.TryGetSettings(out _colorAdjustments);
    }

    void Update()
    {
        if (Input.GetButtonDown("OpenMenu"))
        {
            if (menuOpen)
            {
                tablet.SetActive(false);
                menuOpen = false;
            }
            else
            {
                tablet.SetActive(true);
                menuOpen = true;
            }
        }

        //Not sure if the button would still enable/disable the effects if the parent object is disabled
        if (menuOpen)
        {
          //effects.SetActive(false);
        }
        else
        {
          //effects.SetActive(true);
        }
    }


    public void VignetteOnOff()
    {
        if (effect1.activeSelf)
        {
            //_vignette.active = value;
            effect1.SetActive(false);
        }
        else
        {
            effect1.SetActive(true);
        }
        
    }

    public void ColorAdjustmentsOnOff()
    {
        if (effect2.activeSelf)
        {
            //_colorAdjustments.active = value;
            effect2.SetActive(false);
        }
        else
        {
            effect2.SetActive(true);
        }
        
    }

    public void BlurOnOff()
    {
        if (effect3.activeSelf)
        {
            effect3.SetActive(false);
        //cameraBlur.GetComponent<Post Processing Custom>().enabled = false;
        }
        else
        {
            effect3.SetActive(true);
          //cameraBlur.GetComponent<Post Processing Custom>().enabled = true;
        }
        
    }

    public void RemoveAllSimulations()
    {
        effect1.SetActive(false);
        effect2.SetActive(false);
        effect3.SetActive(false);
      //cameraBlur.GetComponent<Post Processing Custom>.enabled = false;
    }
}

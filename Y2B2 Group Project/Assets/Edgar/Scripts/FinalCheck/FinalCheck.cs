using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCheck : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private GameObject currentCoupledVial;
    [SerializeField] private List<GameObject> stands;
    [SerializeField] private GameObject greenLight;
    [SerializeField] private GameObject redLight;


    [Header("SetUp")]
    [SerializeField] private bool objCoupled;
    [SerializeField] private Transform tp_coupledObj;
    [SerializeField] private bool oneTimeCheck;
    [SerializeField] private string neededPHLevel;
    private bool correctPHVial = false;


    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.GetComponent<Vial>())
    //    {
    //        InteractableObject vial = other.GetComponent<InteractableObject>();
    //        if(vial.coupledHand.name == "LeftHand Controller")
    //        {
    //            if(vial.coupledHand.GetComponent<HandController>().leftGripPressed == true && oneTimeCheck)
    //            {
    //                oneTimeCheck = false;
    //                teleportVial(other.gameObject);
    //            }
    //        }

    //        else if(vial.coupledHand.name == "RightHand Controller")
    //        {
    //            if (vial.coupledHand.GetComponent<HandController>().rightTriggerPressed == true && oneTimeCheck)
    //            {
    //                oneTimeCheck = false;
    //                teleportVial(other.gameObject);
    //            }
    //        }
    //    }

    //    else
    //    {
    //        //play wrong sound
    //    }
    //}

    //teleport vial to stand && deactivate all check bools for grabbing on hand and vial + currently stored obj on player

    //Couple with vial

    //On coupled, check if vial contains acidic, base or neutral fluid
    //If correct for the stand, turn light green
    //Els eturn light red

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == currentCoupledVial)
        {
            oneTimeCheck = false;
            currentCoupledVial = null;
            //lights off
        }
    }

    private void teleportVial(GameObject vial)
    {
        currentCoupledVial = vial;
        vial.transform.position = tp_coupledObj.position;
        vial.transform.rotation = tp_coupledObj.rotation;
        //correctCheck(vial);
    }

    //private void correctCheck(GameObject vial)
    //{
    //    switch(neededPHLevel)
    //    {
    //        case "acidic":
    //            if(vial.GetComponent<InteractableObject>().PHLevel == "acidic")
    //            {
    //                //Light green
    //                correctPHVial = true;
    //            }
    //            else
    //            {
    //                //light red
    //            }
    //            break;


    //        case "base":
    //            if (vial.GetComponent<InteractableObject>().PHLevel == "base")
    //            {
    //                //Light green
    //                correctPHVial = true;
    //            }
    //            else
    //            {
    //                //light red
    //            }
    //            break;


    //        case "neutral":
    //            if (vial.GetComponent<InteractableObject>().PHLevel == "neutral")
    //            {
    //                //Light green
    //                correctPHVial = true;
    //            }
    //            else
    //            {
    //                //light red
    //            }
    //            break;
    //    }

    //    if(stands[0].GetComponent<FinalCheck>().correctPHVial &&
    //       stands[1].GetComponent<FinalCheck>().correctPHVial &&
    //       stands[2].GetComponent<FinalCheck>().correctPHVial)
    //    {
    //        FinishedGame();
    //    }   
    //}

    private void FinishedGame()
    {

    }

}

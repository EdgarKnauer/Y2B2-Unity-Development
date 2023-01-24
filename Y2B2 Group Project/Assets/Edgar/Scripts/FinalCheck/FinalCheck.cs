using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCheck : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private GameObject currentCoupledVial;
    [SerializeField] private List<GameObject> stands;
    [SerializeField] private List<GameObject> lights;


    [Header("SetUp")]
    [SerializeField] private string neededChemComb;


    private void OnTriggerStay(Collider other)
    {
        if(!other.GetComponent<InteractableObject>().isGrabbed)
        {
            if (other.GetComponent<Vial>())
            {
                //turn first light green
                if (other.GetComponent<InteractableObject>().isMixed)
                {
                    //turn second light green
                    switch (neededChemComb)
                    {
                        case "BBlueAndH2O":

                            //turn third light green
                            break;

                        case "BBlueAndHCL":
                            //turn third light green
                            break;

                        case "BBlueAndNaOH":
                            //turn third light green
                            break;
                    }

                    //turn third light green
                }
            }
        }
        
    }    

    private void FinishedGame()
    {

    }
}

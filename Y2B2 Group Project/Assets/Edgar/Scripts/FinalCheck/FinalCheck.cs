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
    public bool vialCorrect = false;
    [SerializeField] private bool gameFinished = false;

    [SerializeField] private AudioSource soundSource;

    private void OnTriggerStay(Collider other)
    {
        if(gameFinished!)
        {
            if (!other.GetComponent<InteractableObject>().isGrabbed)
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
                                if (other.GetComponent<InteractableObject>().BBLueAndH2O)
                                {
                                    //turn third light green
                                    vialCorrect = true;
                                    FinishedGame();
                                }

                                else
                                {
                                    //turn third light red
                                }
                                break;

                            case "BBlueAndHCL":
                                if (other.GetComponent<InteractableObject>().BBLueAndHCL)
                                {
                                    //turn third light green
                                    vialCorrect = true;
                                    FinishedGame();
                                }

                                else
                                {
                                    //turn third light red
                                }
                                break;

                            case "BBlueAndNaOH":
                                if (other.GetComponent<InteractableObject>().BBLueAndNaOH)
                                {
                                    //turn third light green
                                    vialCorrect = true;
                                    FinishedGame();
                                }

                                else
                                {
                                    //turn third light red
                                }
                                break;
                        }
                    }

                    else
                    {
                        //turn second light red
                    }
                }

                else
                {
                    //turn first light red
                }
            }
        }        
        
    }    

    private void FinishedGame()
    {
        if( stands[0].GetComponent<FinalCheck>().vialCorrect && 
            stands[1].GetComponent<FinalCheck>().vialCorrect &&
            stands[2].GetComponent<FinalCheck>().vialCorrect
            )
        {
            gameFinished = true;
            //play finished sound from sound source
            //Start confetty effects particle system on every vial stand
            //Gamestate = finished;
        }  
    }
}

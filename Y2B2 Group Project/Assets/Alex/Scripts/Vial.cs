using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vial : MonoBehaviour
{
    [SerializeField] private bool isSnapped = false;
    private float RotationSpeed = 60f;
    private bool isRotating = false;

    private GameObject coupledVial;
    [SerializeField] private bool canCouple;

    public float fluidLevel = 0f;

    [SerializeField] private GameObject vialLiquid;
    private MusicManager musicManager;

    [SerializeField] private AudioSource dialogueSource;
    [SerializeField] private AudioSource soundSource;

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Vial>() )
        {
            if (!other.GetComponent<InteractableObject>().vialIsFull && !other.GetComponent<InteractableObject>().vialIsEmpty && GetComponent<InteractableObject>().isGrabbed)
            {
                if (canCouple)
                {
                    canCouple = false;
                    coupledVial = other.gameObject;
                }


                InteractableObject interactable = GetComponent<InteractableObject>();
                if (interactable.coupledHand.name == "RightHand Controller")
                //Guidlines for when pouring is possible
                {
                    //Both same liquids
                    if (GetComponent<InteractableObject>().chemicalType == other.GetComponent<InteractableObject>().chemicalType)
                    {
                        //Play error sound

                        AudioClip dialogueClip = musicManager.getAudioClip("Dialogue", "SameChemical");
                        dialogueSource.clip = dialogueClip;
                        dialogueSource.Play();
                    }

                    //BromothymolBlue into any other chemical
                    else if (GetComponent<InteractableObject>().chemicalType == "BromothymolBlue" && other.GetComponent<InteractableObject>().chemicalType != "BromothymolBlue")
                    {
                        GetComponent<InteractableObject>().removingLiquid("BromothymolBlue");                        
                        other.GetComponent<InteractableObject>().addingLiquid("BromothymolBlue");
                        newParent = other.transform;

                        StartCoroutine(PouringLiquid(/*other.transform*/));                        
                    }

                    //Any chemical into BromothymolBlue
                    else if (GetComponent<InteractableObject>().chemicalType != "BromothymolBlue" && other.GetComponent<InteractableObject>().chemicalType == "BromothymolBlue")
                    {
                        switch (GetComponent<InteractableObject>().chemicalType)
                        {
                            case "HCL":
                                GetComponent<InteractableObject>().removingLiquid("HCL");
                                other.GetComponent<InteractableObject>().addingLiquid("HCL"); 
                                break;

                            case "H2O":
                                GetComponent<InteractableObject>().removingLiquid("H2O");
                                other.GetComponent<InteractableObject>().addingLiquid("H2O");
                                break;

                            case "NaOH":
                                GetComponent<InteractableObject>().removingLiquid("NaOH");
                                other.GetComponent<InteractableObject>().addingLiquid("NaOH");
                                break;
                        }
                        newParent = other.transform;

                        StartCoroutine(PouringLiquid(/*other.transform*/));
                    }

                    //Chemical combinations
                    else
                    {
                        //Error sound
                        AudioClip dialogueClip = musicManager.getAudioClip("Dialogue", "DangerousMix");
                        dialogueSource.clip = dialogueClip;
                        dialogueSource.Play();
                    }
                }

                else if (interactable.coupledHand.name == "LeftHand Controller")
                {
                    Debug.Log("This is the recieving vial");
                }

                else
                {
                    Debug.Log("Vial has collided with another vial but has no coupled Hand-Object");
                }
            }

            else
            {
                //Play sound "Wrong" as well as "Vial already full or is empty"
                AudioClip dialogueClip = musicManager.getAudioClip("Dialogue", "MixOnce");
                dialogueSource.clip = dialogueClip;
                dialogueSource.Play();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject == coupledVial)
        {
            canCouple = true;
        }        
    }

    private IEnumerator PouringLiquid(/*Transform newParent*/)
    {
        Transform handModel = GetComponent<InteractableObject>().coupledHand.GetComponent<HandController>().handModel;

        //Transform originalVialParent = transform.parent;
        //Transform originalHandModelParent = handModel.parent;

        //Vector3 originalVialPos = transform.localPosition;
        //Vector3 originalHandModelPos = handModel.localPosition;

        //Quaternion originalVialRot = transform.localRotation;
        //Quaternion originalHandModelRot = handModel.localRotation;
         originalVialParent = transform.parent;
         originalHandModelParent = handModel.parent;

         originalVialPos = transform.localPosition;
         originalHandModelPos = handModel.localPosition;

         originalVialRot = transform.localRotation;
         originalHandModelRot = handModel.localRotation;


        GetComponent<InteractableObject>().coupledHand.GetComponent<HandController>().isPouring = true;

        transform.parent = newParent;
        handModel.parent = transform.parent;
        transform.position = newParent.position + new Vector3(0f, 0.3f, 0.1f);

        StartCoroutine(VialRotation());

        //while(fluidLevel > -0.1f)
        //{
        //    Debug.Log("IsRotating");

        //    if (isRotating)
        //    {
        //        transform.Rotate(Vector3.left * (RotationSpeed * Time.fixedDeltaTime));
        //    }

        //    if (transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 270 || transform.localRotation.eulerAngles.x > 90 && transform.localRotation.eulerAngles.x < 270)
        //    {
        //        fluidLevel -= 0.0005f * Time.fixedDeltaTime;
        //        newParent.GetComponent<Vial>().fluidLevel += 0.0005f * Time.fixedDeltaTime;

        //        vialLiquid.GetComponent<MeshRenderer>().material.SetFloat("FluidLevel", fluidLevel);
        //        newParent.GetComponent<Vial>().vialLiquid.GetComponent<MeshRenderer>().material.SetFloat("FluidColor", newParent.GetComponent<Vial>().fluidLevel);
        //    }
        //}

        transform.parent = originalVialParent;
        handModel.parent = originalHandModelParent;

        transform.localPosition = originalVialPos;
        transform.localRotation = originalVialRot;

        handModel.localPosition = originalHandModelPos;
        handModel.localRotation = originalHandModelRot;

        GetComponent<InteractableObject>().coupledHand.GetComponent<HandController>().isPouring = false;

        yield return null;
    }

    Transform newParent;

    Transform originalVialParent ;
    Transform originalHandModelParent ;

    Vector3 originalVialPos ;
    Vector3 originalHandModelPos ;

    Quaternion originalVialRot ;
    Quaternion originalHandModelRot ;

    private void FixedUpdate()
    {
        if (fluidLevel > -0.11f && isRotating)
        {
            transform.Rotate(new Vector3(0, 0, 1) * (RotationSpeed * Time.deltaTime));

            if (transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 270 || transform.localRotation.eulerAngles.x > 90 && transform.localRotation.eulerAngles.x < 270)
            {
                fluidLevel -= 0.005f;
                newParent.GetComponent<Vial>().fluidLevel += 0.005f;                
            }
        }

        vialLiquid.GetComponent<MeshRenderer>().material.SetFloat("FluidLevel", fluidLevel);
    }
        
    private IEnumerator VialRotation()
    {
        Debug.Log("Started rotation timer");
        isRotating = true;
        yield return new WaitForSeconds(2);
        isRotating = false;
        Debug.Log("Ended rotation timer");
    }

}
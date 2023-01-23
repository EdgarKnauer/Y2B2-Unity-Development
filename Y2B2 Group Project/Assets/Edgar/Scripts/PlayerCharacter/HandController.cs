using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class HandController : MonoBehaviour
{
    [SerializeField] private XRNode leftController;
    [SerializeField] private XRNode rightController;

    public bool leftTriggerPressed;
    public bool rightTriggerPressed;

    [SerializeField] private GameObject hand;
    private PlayerController playerController;
    [SerializeField] private Transform grabbedObjHandTransform;
    [SerializeField] private Transform classroomParentTransform;

    [SerializeField] private GameObject objLeftHand;
    [SerializeField] private GameObject objRightHand;

    [SerializeField] private bool objGrabbedLH = false;
    [SerializeField] private bool objGrabbedRH = false;

    public Transform handModel;
    public bool isPouring;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        InputDevice leftDevice = InputDevices.GetDeviceAtXRNode(leftController);
        InputDevice rightDevice = InputDevices.GetDeviceAtXRNode(rightController);

        leftDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftTriggerPressed);
        rightDevice.TryGetFeatureValue(CommonUsages.triggerButton, out rightTriggerPressed);
    }


    private void OnTriggerStay(Collider other)
    {
        if (!isPouring)
        {
            if (other.GetComponent<InteractableObject>())
            {
                if (!objGrabbedLH)
                {
                    if (leftTriggerPressed && hand.name == "LeftHand Controller" && !other.GetComponent<InteractableObject>().isGrabbed)
                    {
                        objGrabbedLH = true;
                        objLeftHand = other.gameObject;


                        objLeftHand.transform.position = grabbedObjHandTransform.position;
                        objLeftHand.transform.rotation = grabbedObjHandTransform.rotation;
                        objLeftHand.transform.parent = grabbedObjHandTransform;
                        objLeftHand.GetComponent<Rigidbody>().isKinematic = true;
                        objLeftHand.GetComponent<InteractableObject>().isGrabbed = true;
                        objLeftHand.GetComponent<InteractableObject>().coupledHand = gameObject;

                        playerController.grabbedObjLeftHand = objLeftHand.gameObject;
                    }
                }

                else
                {
                    if (!leftTriggerPressed && hand.name == "LeftHand Controller")
                    {
                        if (objLeftHand != null)
                        {
                            objLeftHand.transform.parent = classroomParentTransform;
                            objLeftHand.GetComponent<Rigidbody>().isKinematic = false;
                            objLeftHand.GetComponent<InteractableObject>().isGrabbed = false;
                            objLeftHand.GetComponent<InteractableObject>().coupledHand = null;

                            playerController.grabbedObjLeftHand = null;
                            objLeftHand = null;
                            objGrabbedLH = false;
                        }
                    }
                }

                if (!objGrabbedRH)
                {
                    if (rightTriggerPressed && hand.name == "RightHand Controller" && !other.GetComponent<InteractableObject>().isGrabbed)
                    {
                        objGrabbedRH = true;
                        objRightHand = other.gameObject;

                        objRightHand.transform.position = grabbedObjHandTransform.position;
                        objRightHand.transform.rotation = grabbedObjHandTransform.rotation;
                        objRightHand.transform.parent = grabbedObjHandTransform;
                        objRightHand.GetComponent<Rigidbody>().isKinematic = true;
                        objRightHand.GetComponent<InteractableObject>().isGrabbed = true;
                        objRightHand.GetComponent<InteractableObject>().coupledHand = gameObject;

                        playerController.grabbedObjRightHand = objRightHand.gameObject;
                    }
                }

                else
                {
                    if (!rightTriggerPressed && hand.name == "RightHand Controller")
                    {
                        if (objRightHand != null)
                        {
                            objRightHand.transform.parent = classroomParentTransform;
                            objRightHand.GetComponent<Rigidbody>().isKinematic = false;
                            objRightHand.GetComponent<InteractableObject>().isGrabbed = false;
                            objRightHand.GetComponent<InteractableObject>().coupledHand = null;

                            playerController.grabbedObjRightHand = null;
                            objRightHand = null;
                            objGrabbedRH = false;
                        }
                    }
                }
            }
        }
    }
}
